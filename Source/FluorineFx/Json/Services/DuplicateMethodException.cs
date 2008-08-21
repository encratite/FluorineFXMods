//JSON RPC based on Jayrock - JSON and JSON-RPC for Microsoft .NET Framework and Mono
//http://jayrock.berlios.de/
using System;
using System.Runtime.Serialization;
using FluorineFx.Util;

namespace FluorineFx.Json.Services
{
    [ Serializable ]
    public class DuplicateMethodException : ApplicationException
    {
        private const string _defaultMessage = "A method with the same name has been defined elsewhere on the service.";
        
        public DuplicateMethodException() : this(null) {}

        public DuplicateMethodException(string message) : 
            base(StringUtils.MaskNullString(message, _defaultMessage)) {}

        public DuplicateMethodException(string message, Exception innerException) :
            base(StringUtils.MaskNullString(message, _defaultMessage), innerException) { }

        protected DuplicateMethodException(SerializationInfo info, StreamingContext context) :
            base(info, context) {}
    }
}