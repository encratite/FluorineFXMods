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
using FluorineFx.WCF.Channels;

namespace FluorineFx.WCF.Configuration
{
    /// <summary>
    /// This class is necessary to be able to plug in the FluorineFx encoder binding element through a configuration file.
    /// </summary>
    public sealed class FluorineLegacyMessageEncodingElement : BindingElementExtensionElement
    {
        public FluorineLegacyMessageEncodingElement()
        {
        }

        //Called by the WCF to discover the type of binding element this config section enables
        public override Type BindingElementType
        {
            get { return typeof(FluorineLegacyMessageEncodingBindingElement); }
        }

        /*
        //The only property we need to configure for our binding element is the type of
        //inner encoder to use. Here, we support text and binary.
        [ConfigurationProperty("innerMessageEncoding", DefaultValue = "textMessageEncoding")]
        public string InnerMessageEncoding
        {
            get { return (string)base["innerMessageEncoding"]; }
            set { base["innerMessageEncoding"] = value; }
        }
        */

        //Called by the WCF to apply the configuration settings (the property above) to the binding element
        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            FluorineLegacyMessageEncodingBindingElement binding = (FluorineLegacyMessageEncodingBindingElement)bindingElement;
            PropertyInformationCollection propertyInfo = this.ElementInformation.Properties;
            /*
            if (propertyInfo["innerMessageEncoding"].ValueOrigin != PropertyValueOrigin.Default)
            {
                switch ((string)base["innerMessageEncoding"])
                {
                    case "textMessageEncoding":
                        //binding.InnerMessageEncodingBindingElement = new TextMessageEncodingBindingElement();
                        throw new ConfigurationErrorsException("An inner message encoder must not be specificied");
                    case "binaryMessageEncoding":
                        //binding.InnerMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
                        throw new ConfigurationErrorsException("An inner message encoder must not be specificied");
                }
            }
            */
        }

        /// <summary>
        /// Called by the WCF to create the binding element
        /// </summary>
        /// <returns></returns>
        protected override BindingElement CreateBindingElement()
        {
            FluorineLegacyMessageEncodingBindingElement bindingElement = new FluorineLegacyMessageEncodingBindingElement();
            this.ApplyConfiguration(bindingElement);
            return bindingElement;
        }
    }
}
