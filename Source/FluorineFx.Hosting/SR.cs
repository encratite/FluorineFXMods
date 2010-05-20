using System;
using System.Resources;

namespace FluorineFx.Hosting
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class SR
	{
		private static ResourceManager _resMgr;
        internal const string IoDirectoryNotFoundPath = "IoDirectoryNotFoundPath";
        internal const string NotIRegisteredObject = "NotIRegisteredObject";
        internal const string WellknownObjectAlreadyExists = "WellknownObjectAlreadyExists";
        internal const string HostingEnvRestart = "HostingEnvRestart";

		internal static string GetString(string key)
		{
			if (_resMgr == null)
			{
                _resMgr = new ResourceManager("FluorineFx.Hosting.Resources.Resource", typeof(SR).Assembly);
			}
			string text = _resMgr.GetString(key);
			if (text == null)
			{
                throw new ApplicationException("Missing resource from FluorineFx.Hosting library!  Key: " + key);
			}
			return text;
		}

		internal static string GetString(string key, params object[] inserts)
		{
			return string.Format(GetString(key), inserts);
		}
	}
}
