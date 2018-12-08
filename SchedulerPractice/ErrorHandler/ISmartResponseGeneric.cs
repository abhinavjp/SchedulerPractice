using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerPractice.ErrorHandler
{
    public interface ISmartResponse<T> : ISmartResponse
    {
        T Response { get; set; }
    }
}
