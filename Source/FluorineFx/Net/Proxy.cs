using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FluorineFx.Net
{
	public enum ProxyType
	{
		HTTP,
		SOCKS4,
		SOCKS4a,
		SOCKS5
	}

	public class Proxy
	{
		public string Server;
		public ProxyType Type;

		/// <summary>
		/// Converts a ProxyType to the ProxyType used by the internal proxy library
		/// </summary>
		/// <returns></returns>
		internal Starksoft.Net.Proxy.ProxyType TypeToInternalType()
		{
			switch (Type)
			{
				case ProxyType.HTTP:
					return Starksoft.Net.Proxy.ProxyType.Http;
				case ProxyType.SOCKS4:
					return Starksoft.Net.Proxy.ProxyType.Socks4;
				case ProxyType.SOCKS4a:
					return Starksoft.Net.Proxy.ProxyType.Socks4a;
				case ProxyType.SOCKS5:
					return Starksoft.Net.Proxy.ProxyType.Socks5;
				default:
					throw new NotImplementedException("Unknown proxy type");
			}
		}
	}
}
