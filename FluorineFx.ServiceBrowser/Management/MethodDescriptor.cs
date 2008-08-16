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
using System.Collections;
using System.Reflection;

namespace FluorineFx.Management
{
	/// <summary>
	/// Summary description for MethodDescriptor.
	/// </summary>
	[Serializable]
	public class MethodDescriptor : NamedObject
	{
		ParameterDescriptor[] _parameters;
		ParameterTypeDescriptor _returnValue;
		string _fullName;
		string _declaringType;

		public MethodDescriptor()
		{
		}

		public void Build(MethodInfo methodInfo)
		{
			_name = methodInfo.Name;
			_declaringType = methodInfo.DeclaringType.FullName;
			_fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name;
			ArrayList parameters = new ArrayList();
			if( methodInfo.GetParameters() != null && methodInfo.GetParameters().Length > 0 )
			{
				foreach(ParameterInfo parameterInfo in methodInfo.GetParameters())
				{
					ParameterDescriptor parameterDescriptor = new ParameterDescriptor();
					parameterDescriptor.Build(parameterInfo);
					parameters.Add(parameterDescriptor);
				}
			}
			_returnValue = new ParameterTypeDescriptor();
			_returnValue.Build(methodInfo.ReturnType);
			_parameters = parameters.ToArray(typeof(ParameterDescriptor)) as ParameterDescriptor[];

			object[] attrs = methodInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
			if( attrs.Length > 0 )
			{
				System.ComponentModel.DescriptionAttribute descriptionAttribute = attrs[0] as System.ComponentModel.DescriptionAttribute;
				_description = descriptionAttribute.Description;
			}
		}

		public string DeclaringType
		{
			get{ return _declaringType; }
			set{ _declaringType = value; }
		}

		public string FullName
		{
			get{ return _fullName; }
			set{ _fullName = value; }
		}

		public ParameterDescriptor[] Parameters
		{
			get{ return _parameters; }
			set{ _parameters = value; }
		}

		public ParameterTypeDescriptor ReturnValue
		{
			get{ return _returnValue; }
			set{ _returnValue = value; }
		}
	}
}
