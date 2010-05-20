/*
	FluorineFx open source library 
	Copyright (C) 2010 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
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
using System.Xml;
using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.Text;

namespace FluorineFx.WCF.Channels
{
    /// <summary>
    /// This is the binding element that, when plugged into a custom binding, will enable the AMF encoder
    /// </summary>
    sealed class FluorineLegacyMessageEncodingBindingElement : MessageEncodingBindingElement, IPolicyExportExtension
    {
        public FluorineLegacyMessageEncodingBindingElement()
        { }

        /// <summary>
        /// Main entry point into the encoder binding element. Called by WCF to get the factory that will create the message encoder.
        /// </summary>
        /// <returns></returns>
        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new FluorineLegacyMessageEncoderFactory();
        }

        public override MessageVersion MessageVersion
        {
            get { return MessageVersion.None; }
            set { ; }
        }

        public override BindingElement Clone()
        {
            return new FluorineLegacyMessageEncodingBindingElement();
        }

        public override T GetProperty<T>(BindingContext context)
        {
            /*
            if (typeof(T) == typeof(XmlDictionaryReaderQuotas))
            {
                return innerBindingElement.GetProperty<T>(context);
            }
            else
            {
                return base.GetProperty<T>(context);
            }
            */
            return base.GetProperty<T>(context);
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelFactory<TChannel>();
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelListener<TChannel>();
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.CanBuildInnerChannelListener<TChannel>();
        }

        #region IPolicyExportExtension Members

        public void ExportPolicy(MetadataExporter exporter, PolicyConversionContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
