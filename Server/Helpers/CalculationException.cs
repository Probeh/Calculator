using System;
using System.Runtime.Serialization;

namespace Server.Helpers {
    public class CalculationException : Exception {
        public CalculationException() { }
        public CalculationException(string message) : base(message) { }
        public CalculationException(string message, Exception innerException) : base(message, innerException) { }
        protected CalculationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}