/*
	FluorineFx open source library 
	Copyright (C) 2007 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
	This library is free software; you can redistribute it and/or
	modify it under the terms of the GNU Lesser General Public
	License as published by the Free Software Foundation; either
	version 2.1 of the License, or (at your option) any later version.
	
	This library is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
	Lesser General Public License for more details.
	
	You should have received a copy of the GNU Lesser General Public
	License along with this library; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Reflection;
using System.CodeDom.Compiler;
using log4net;
using FluorineFx.CodeGenerator.Parser;
using FluorineFx.Util;

namespace FluorineFx.CodeGenerator
{
	/// <summary>
	/// Summary description for Generator.
	/// </summary>
	public class TemplateEngine : ITemplateEngine
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(TemplateEngine));

		TemplateEngineSettings _templateEngineSettings;
		StringBuilder	_contentBuilder;
		StringBuilder	_codeBuilder;
        Hashtable _compiledAssemblies;
		/*
		Hashtable		_directives;
		Hashtable		_imports;
		Hashtable		_assemblies;
		*/

		Stack			_templateContextStack;
		TemplateContext	_currentTemplateContext;

		public TemplateEngine()
		{
			_templateContextStack = new Stack();
            _compiledAssemblies = new Hashtable();
		}

		void PushContext(TemplateContext templateContext)
		{
			if( _currentTemplateContext != null )
				_templateContextStack.Push(_currentTemplateContext);
			_currentTemplateContext = templateContext;
		}

		internal void PopContext()
		{
			if( _templateContextStack.Count > 0 )
				_currentTemplateContext = _templateContextStack.Pop() as TemplateContext;
			else
				_currentTemplateContext = null;
		}

		public void Execute(TemplateInfo templateInfo, ITemplateGeneratorHost host)
		{
			Execute(templateInfo, host, TemplateEngineSettings.Default);
		}

		public void Execute(TemplateInfo templateInfo, ITemplateGeneratorHost host, TemplateEngineSettings templateEngineSettings)
		{
			_templateEngineSettings = templateEngineSettings;
			string relativePath = "";
			try
			{
				host.Open();
				ProcessTemplates(relativePath, templateInfo.Directory, host);
			}
			finally
			{
				host.Close();
			}
		}

		public string Preview(TemplateInfo templateInfo, ITemplateGeneratorHost host, TemplateEngineSettings templateEngineSettings)
		{
			ValidationUtils.ArgumentNotNull(templateInfo, "templateInfo");
			ValidationUtils.ArgumentNotNull(host, "host");
			ValidationUtils.ArgumentNotNull(templateEngineSettings, "templateEngineSettings");

			log.Debug(string.Format("Running template {0} from {1}", templateInfo.Name, templateInfo.Directory));
			string result;
			try
			{
				_templateEngineSettings = templateEngineSettings;
				string relativePath = "";
				string templateFile = Path.Combine(templateInfo.Directory, "preview.template");

				TemplateContext templateContext = new TemplateContext(relativePath, templateInfo.Directory, host);
				PushContext(templateContext);
				result = InternalProcessTemplate(relativePath, templateFile, "preview",  host);
				PopContext();
			}
			catch(Exception ex)
			{
				log.Error("Failed generating template preview", ex);
				throw ex;
			}
			//log.Debug(result);
			return result;
		}

		private void ProcessTemplates(string relativePath, string srcDirectory, ITemplateGeneratorHost host)
		{
			//foreach(string file in Directory.GetFiles(srcDirectory, "*.config.template"))
			foreach(string file in Directory.GetFiles(srcDirectory))
			{
				if( Path.GetExtension(file).ToLower() == ".template" )
				{
					string outFileName = Path.GetFileName(file);
					outFileName = outFileName.Substring(0, outFileName.Length - ".template".Length);

					TemplateContext templateContext = new TemplateContext(relativePath, srcDirectory, host);
					PushContext(templateContext);

					ProcessTemplate(relativePath, file, outFileName, host);

					PopContext();
				}
				else if( Path.GetExtension(file).ToLower() == ".subtemplate" )
				{
					//ignore subtemplates
				}				
				else
				{
					host.AddFile(relativePath, file);
				}
			}
			foreach(string dir in Directory.GetDirectories(srcDirectory))
			{
				DirectoryInfo info = new DirectoryInfo(dir);
				if( info.Name.StartsWith("_") )
					continue;//Ignore special folders
				string relativePathTmp = Path.Combine(relativePath, info.Name);
				ProcessTemplates(relativePathTmp, dir, host);
			}
		}

		internal void ParseSubDirectory(string templateDirectory, string outDirectory)
		{
			if(_currentTemplateContext != null)
			{
				string srcDirectory = Path.Combine(_currentTemplateContext.TemplateDirectory, templateDirectory);
				string relativePath = Path.Combine(_currentTemplateContext.RelativePath, outDirectory);
				ProcessTemplates(relativePath, srcDirectory, _currentTemplateContext.TemplateGeneratorHost);
			}
		}

		protected void ProcessTemplate(string relativePath, string templateFile, string outFileName, ITemplateGeneratorHost host)
		{
			string result = InternalProcessTemplate(relativePath, templateFile, outFileName, host);

			OutputType outputType = OutputType.Normal;
			TagAttributes codeTemplateAttributes = _currentTemplateContext.Directives["CodeTemplate"] as TagAttributes;
			if( codeTemplateAttributes != null )
			{
				string tmp = codeTemplateAttributes["OutputType"] as string;
				if (tmp != null)
				{
					try 
					{
						outputType = (OutputType)Enum.Parse(typeof(OutputType), tmp, true);
					}
					catch(ArgumentException) { }
				}
			}

			if( outputType == OutputType.Normal )
			{
				host.AddFile(relativePath, outFileName, result);
			}
		}

		private string InternalProcessTemplate(string relativePath, string templateFile, string outFileName, ITemplateGeneratorHost host)
		{
			string filename = Path.GetFileName(templateFile);
			log.Debug(string.Format("Internal processing template {0}", templateFile));

			_contentBuilder = new StringBuilder();
			_codeBuilder = new StringBuilder();
			//_directives = new Hashtable();
			//_imports = new Hashtable();
			//_assemblies = new Hashtable();
			using(StreamReader streamReader = new StreamReader(templateFile))
			{
				TemplateParser parser = new TemplateParser(templateFile, streamReader);
				try
				{
					parser.Error += new ParseErrorHandler(ParserError);
					parser.TagParsed += new TagParsedHandler(TagParsed);
					parser.TextParsed += new TextParsedHandler(TextParsed);
					parser.Parse();

					DumpContent();
				}
				catch(Exception ex)
				{
					log.Debug(string.Format("Template parser failed", ex));
				}
				finally
				{
					parser.Error -= new ParseErrorHandler(ParserError);
					parser.TagParsed -= new TagParsedHandler(TagParsed);
					parser.TextParsed -= new TextParsedHandler(TextParsed);
					parser = null;
				}
			}

			string result = Execute(host, relativePath, templateFile, outFileName);
			return result;
		}

		/// <summary>
		/// Called from a Template class.
		/// </summary>
		/// <param name="templateFileName"></param>
		/// <param name="outFileName"></param>
		internal void ProcessTemplate(string templateFileName, string outFileName)
		{
			TemplateContext templateContext = new TemplateContext(_currentTemplateContext);
			PushContext(templateContext);
			string templateFile = Path.Combine(_currentTemplateContext.TemplateDirectory, templateFileName);
			ProcessTemplate(_currentTemplateContext.RelativePath, templateFile, outFileName, _currentTemplateContext.TemplateGeneratorHost);
			PopContext();
		}

		private string Execute(ITemplateGeneratorHost host, string relativePath, string templateFile, string outFileName)
		{
            Type compiledType = null;
            if (!_compiledAssemblies.Contains(templateFile))
            {
                string guid = Guid.NewGuid().ToString("N");
                string generatorClassName = "Template" + guid;
                string import = @"using System;
using System.Collections;
";

                foreach (DictionaryEntry entry in _currentTemplateContext.Imports)
                {
                    TagAttributes tagAttributes = entry.Value as TagAttributes;
                    import += "using " + tagAttributes["Namespace"].ToString() + ";\r\n";
                }

                string prefix = @"
namespace FluorineFx.CodeGenerator
{
	public class " + generatorClassName + @" : Template
	{
		public " + generatorClassName + @"(TemplateEngine templateEngine, ITemplateGeneratorHost host, TemplateContext templateContext) : base(templateEngine, host, templateContext)
		{
		}

		public void RunTemplate()
		{";

                string suffix = @"
		}
	}
}";

                string code = import + prefix + _codeBuilder.ToString() + suffix;

                if (_templateEngineSettings.Trace)
                {
                    host.AddFile(relativePath, outFileName + ".trace.cs", code);
                }

                CodeDomProvider provider = null;
                //Microsoft.CSharp.CSharpCodeProvider provider = new Microsoft.CSharp.CSharpCodeProvider();
                //Microsoft.VisualBasic.VBCodeProvider provider = new Microsoft.VisualBasic.VBCodeProvider();
                provider = new Microsoft.CSharp.CSharpCodeProvider();
#if (NET_1_1)
			ICodeCompiler compiler = provider.CreateCompiler();
#endif
                CompilerParameters options = new CompilerParameters();
                options.GenerateInMemory = true;
                options.GenerateExecutable = false;
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    //options.ReferencedAssemblies.Add(Path.GetFileName(assembly.Location));
                    options.ReferencedAssemblies.Add(assembly.Location);
                }

                Uri uri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
                string libPath = Path.GetDirectoryName(uri.LocalPath);
                options.CompilerOptions = "/lib:\"" + libPath + "\"";
                if (AppDomain.CurrentDomain.BaseDirectory != null)
                    options.CompilerOptions += " /lib:\"" + Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\"";
                if (AppDomain.CurrentDomain.DynamicDirectory != null)
                    options.CompilerOptions += " /lib:\"" + Path.GetDirectoryName(AppDomain.CurrentDomain.DynamicDirectory) + "\"";

                foreach (DictionaryEntry entry in _currentTemplateContext.Assemblies)
                {
                    TagAttributes tagAttributes = entry.Value as TagAttributes;
                    bool referenced = false;
                    foreach (string referencedAssembly in options.ReferencedAssemblies)
                    {
                        string assembly = Path.GetFileName(referencedAssembly);
                        if (assembly.ToLower() == tagAttributes["Name"].ToString().ToLower())
                        {
                            referenced = true;
                            break;
                        }
                    }
                    if (!referenced)
                        options.ReferencedAssemblies.Add(tagAttributes["Name"].ToString());
                }

                //log.Debug("Compiling code");
                //log.Debug(code);

                /*
                string output = Path.Combine(Path.GetTempPath(), generatorClassName + ".cs");
                using (StreamWriter sw = File.CreateText(output))
                {
                    sw.Write(code);
                }
                */

#if (NET_1_1)
			CompilerResults results = compiler.CompileAssemblyFromSource(options, code);
#else
                CompilerResults results = provider.CompileAssemblyFromSource(options, code);
                //CompilerResults results = provider.CompileAssemblyFromFile(options, output);
#endif
                if (results.Errors.Count != 0)
                {
                    StringBuilder errorBuilder = new StringBuilder();
                    errorBuilder.Append("*** Compilation Errors ***\n");
                    log.Error("*** Compilation Errors ***");
                    foreach (CompilerError error in results.Errors)
                    {
                        errorBuilder.Append(error.Line + ", " + error.Column + ", " + error.ErrorNumber + ": ");
                        errorBuilder.Append(error.ErrorText);
                        errorBuilder.Append("\r\n");
                        log.Error(error.Line + ", " + error.Column + ", " + error.ErrorNumber + ": " + error.ErrorText);
                    }
                    host.AddFile(relativePath, outFileName + ".error.txt", errorBuilder.ToString());
                    return errorBuilder.ToString();
                }

                compiledType = results.CompiledAssembly.GetType("FluorineFx.CodeGenerator." + generatorClassName);
                _compiledAssemblies[templateFile] = compiledType;
            }
            else
                compiledType = _compiledAssemblies[templateFile] as Type;

			TextWriter saved = Console.Out;
			StringWriter writer = new StringWriter();
			Console.SetOut(writer);
			try
			{
                object generator = Activator.CreateInstance(compiledType, new object[] { this, host, _currentTemplateContext });//Assembly.CreateInstance("FluorineFx.CodeGenerator." + generatorClassName, true, BindingFlags.Public | BindingFlags.Instance, null, new object[] { this, host, _currentTemplateContext }, null, null);
				MethodInfo mi = generator.GetType().GetMethod("RunTemplate");
				mi.Invoke(generator, new object[]{} );
				return writer.ToString();
			}
			catch (Exception ex)
			{
				log.Error("Error calling code generator", ex);
				Console.SetOut(saved);
				//Console.WriteLine(code.ToString());
				Console.WriteLine();
				Console.WriteLine("Unable to invoke entry point: {0}", ex.Message);
				if (ex.InnerException != null)
					Console.WriteLine(ex.InnerException);
				return ex.ToString();
			}
			finally
			{
				Console.SetOut(saved);
			}
		}

		private void TagParsed(ILocation location, TagType tagtype, string tagid, TagAttributes attributes)
		{
			switch(tagtype)
			{
				case TagType.Directive:
					ProcessDirective (tagid, attributes);
					break;
				case TagType.ServerComment:
					break;
				case TagType.CodeRender:
				{
					DumpContent();
					_codeBuilder.Append(tagid);
					_contentBuilder.Length = 0;
				}
					break;
				case TagType.CodeRenderExpression:
				{
					DumpContent();
					string str = string.Format("System.Console.Write({0});\n", tagid);
					_codeBuilder.Append(str);
					_contentBuilder.Length = 0;
				}
					break;
			}
		}

		internal void Echo(string text)
		{
			System.Console.Write(text);
		}

		private void DumpContent()
		{
			_codeBuilder.Append("\n");
			_contentBuilder.Replace("\\", "\\\\");
			_contentBuilder.Replace("\"", "\\\"");
			_contentBuilder.Replace("\n", "\\n");
			_contentBuilder.Replace("\r", "\\r");
			_contentBuilder.Replace("\t", "\\t");
			string content = _contentBuilder.ToString();

			string[] parts = SplitByLength(content, 1500);
			for(int i = 0; i < parts.Length; i++)
			{
				string tmp = parts[i];
				string str = string.Format("System.Console.Write(\"{0}\");", tmp);
				_codeBuilder.Append(str);
				_codeBuilder.Append("\r\n");
			}
		}

		private string[] SplitByLength(string text, int length)
		{
			if( text == string.Empty )
				return new string[0];
			string[] result = new string[(text.Length+length-1)/length];
			for (int i=0; i < result.Length-1; i++)
			{
				result[i] = text.Substring(i*length, length);
			}
			result[result.Length-1] = text.Substring ((result.Length-1)*length);
			return result;
		}

		void ProcessDirective (string tagid, TagAttributes attributes)
		{
			if( tagid == "Import" )
			{
				_currentTemplateContext.Imports[attributes["Namespace"]] = attributes;
				return;
			}
			if( tagid == "Assembly" )
			{
				_currentTemplateContext.Assemblies[attributes["Name"]] = attributes;
				return;
			}
			_currentTemplateContext.Directives[tagid] = attributes;
		}

		private void ParserError(ILocation location, string message)
		{
			throw new ParseException(location, message);
		}

		private void TextParsed(ILocation location, string text)
		{
			_contentBuilder.Append(text);
		}
	}
}
