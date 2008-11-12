using System.Collections;
using System.Xml;

namespace FluorineFx.NMS
{
    public sealed class NMSSettings : Hashtable
    {
        public const string QueueDestination = "QueueDestination";
        public const string TopicDestination = "TopicDestination";

        private NMSSettings()
        {
        }

        internal NMSSettings(XmlNode nmsDefinitionNode)
        {
            foreach (XmlNode propertyNode in nmsDefinitionNode.SelectNodes("*"))
            {
                if (propertyNode.InnerXml != null && propertyNode.InnerXml != string.Empty)
                    this[propertyNode.Name] = propertyNode.InnerXml;
                else
                {
                    if (propertyNode.Attributes != null)
                    {
                        foreach (XmlAttribute attribute in propertyNode.Attributes)
                        {
                            this[propertyNode.Name + "_" + attribute.Name] = attribute.Value;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gets the URI of the NMS server.
        /// </summary>
        public string URI
        {
            get
            {
                if (this.ContainsKey("URI"))
                    return this["URI"] as string;
                return null;
            }
        }
        /// <summary>
        /// Gets the name of the NMS destination.
        /// </summary>
        public string Destination
        {
            get
            {
                if (this.ContainsKey("destination"))
                    return this["destination"] as string;
                return null;
            }
        }
        /// <summary>
        /// Gets the destination type.
        /// </summary>
        public string DESTINATION_TYPE
        {
            get
            {
                if (this.ContainsKey("destinationType"))
                    return this["destinationType"] as string;
                return null;
            }
        }
    }
}
