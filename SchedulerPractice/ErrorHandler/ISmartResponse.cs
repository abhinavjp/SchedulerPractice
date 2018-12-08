using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerPractice.ErrorHandler
{
    public interface ISmartResponse
    {
        Dictionary<string, object> AdditionalData { get; set; }
        string SuccessMessage { get; set; }
        ResponseStatusCode ResponseStatusCode { get; set; }
        int Id { get; set; }
        List<SmartError> Errors { get; set; }
        bool IsPositiveResponse { get; }
    }
}
