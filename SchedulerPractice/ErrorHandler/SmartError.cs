using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerPractice.ErrorHandler
{
    public class SmartError
    {
        public SmartError(string errorMessage, ErrorType errorType)
            : this(new List<string> { errorMessage }, null, string.Empty, errorType)
        {

        }

        public SmartError(List<string> errorMessages, List<string> stackTrace, string targetMethod, ErrorType errorType)
        {
            ErrorMessages = errorMessages;
            StackTrace = stackTrace;
            TargetMethod = targetMethod;
            ErrorType = errorType;
        }
        public ErrorType ErrorType { get; set; }
        public List<string> ErrorMessages { get; set; }
        public List<string> StackTrace { get; set; }
        public string TargetMethod { get; set; }
        internal List<SmartError> SmartErrorList => new List<SmartError> { this };
    }
}
