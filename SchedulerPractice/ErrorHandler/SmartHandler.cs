using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerPractice.ErrorHandler
{
    public static class SmartHandler
    {
        public static ISmartResponse Handle(Action action, string moduleName, params object[] logObjects)
        {
            try
            {
                action?.Invoke();
                return SmartResponse.Done;
            }
            catch (Exception exception)
            {
                return exception.WriteException();
            }
        }

        public static ISmartResponse<T> Handle<T>(Func<T> action, string moduleName, params object[] logObjects)
        {
            try
            {
                return SmartResponse.WriteResponse(action());
            }
            catch (Exception exception)
            {
                return exception.WriteException<T>();
            }
        }
    }
}
