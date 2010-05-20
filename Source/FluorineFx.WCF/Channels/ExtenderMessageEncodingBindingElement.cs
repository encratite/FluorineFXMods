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
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using FluorineFx.Util;

namespace FluorineFx.WCF.Channels
{
    public abstract class ExtenderMessageEncodingBindingElement : MessageEncodingBindingElement, IBindingElementExtender
    {
        protected ExtenderMessageEncodingBindingElement()
        {
        }

        #region IBindingElementExtender Members

        public CustomBinding Extend(Binding binding)
        {
            BindingElementCollection bindingElements = binding.CreateBindingElements();
            return new CustomBinding(this.Extend(bindingElements));
        }

        public BindingElementCollection Extend(BindingElementCollection bindingElementCollection)
        {
            MessageEncodingBindingElement item = bindingElementCollection.Find<MessageEncodingBindingElement>();
            if (item != null)
            {
                ConfigureFromMessageEncodingBindingElement(item);
                int index = bindingElementCollection.IndexOf(item);
                bindingElementCollection.RemoveAt(index);
                bindingElementCollection.Insert(index, this);
                return bindingElementCollection;
            }
            bindingElementCollection.Insert(0, this);
            return bindingElementCollection;
        }

        #endregion

        protected virtual void ConfigureFromMessageEncodingBindingElement(MessageEncodingBindingElement source)
        {
        }
    }
}
