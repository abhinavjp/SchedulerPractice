using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerPractice.ErrorHandler
{
    public class SmartResponse<T> : ISmartResponse<T>
    {
        internal SmartResponse()
        {

        }
        public Dictionary<string, object> AdditionalData { get; set; }
        public T Response { get; set; }
        public string SuccessMessage { get; set; }
        public ResponseStatusCode ResponseStatusCode { get; set; }
        public int Id { get; set; }
        public List<SmartError> Errors { get; set; }
        public bool IsPositiveResponse => Errors == null || !Errors.Any();
    }

    

}
