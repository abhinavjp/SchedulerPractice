using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerPractice.ErrorHandler
{

    public class SmartResponseException : Exception
    {
        public ErrorType ErrorType { get; set; }
        public ResponseStatusCode StatusCode { get; set; }

        public SmartResponseException(string message) : this(message, ErrorType.Warning)
        {
        }

        public SmartResponseException(string message, ResponseStatusCode statusCode) : this(message, ErrorType.Warning, statusCode)
        {
        }

        public SmartResponseException(string message, ErrorType errorType) : this(message, errorType, GetStatusCode(errorType))
        {
        }

        public SmartResponseException(string message, ErrorType errorType, ResponseStatusCode statusCode) : base(message)
        {
            ErrorType = errorType;
            StatusCode = statusCode;
        }

        private static ResponseStatusCode GetStatusCode(ErrorType errorType)
        {
            switch (errorType)
            {
                case ErrorType.Warning:
                    return ResponseStatusCode.PreconditionFailed;
                default:
                    return ResponseStatusCode.BadRequest;
            }
        }
    }
}
