using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.Validation;
using System.Linq;

namespace SchedulerPractice.ErrorHandler
{
    public static class SmartResponse
    {
        private const ResponseStatusCode DefaultValidationStatusCode = ResponseStatusCode.PreconditionFailed;
        private const ResponseStatusCode FatalValidationStatusCode = ResponseStatusCode.BadRequest;
        private const ErrorType DefaultValidationErrorType = ErrorType.Warning;
        private const ErrorType FatalValidationErrorType = ErrorType.Error;

        public static ISmartResponse Done => new SmartResponse<int>();
        public static ISmartResponse DoneWith(string message)
        {
            return DoneWith(message, null);
        }
        public static ISmartResponse DoneWith(string message, Dictionary<string, object> additionalData)
        {
            return DoneWith(default, message, additionalData);
        }
        public static ISmartResponse DoneWith(int id)
        {
            return DoneWith(id, default(Dictionary<string, object>));
        }
        public static ISmartResponse DoneWith(int id, Dictionary<string, object> additionalData)
        {
            return DoneWith(id, null, additionalData);
        }
        public static ISmartResponse DoneWith(int id, string message)
        {
            return DoneWith(id, message, null);
        }
        public static ISmartResponse DoneWith(int id, string message, Dictionary<string, object> additionalData)
        {
            return new SmartResponse<int> { Id = id, SuccessMessage = message, AdditionalData = additionalData };
        }


        #region Postive Results
        public static ISmartResponse<T> WriteResponse<T>(this T result)
        {
            return WriteResponse(result, default(Dictionary<string, object>));
        }
        public static ISmartResponse<T> WriteResponse<T>(this T result, Dictionary<string, object> additionalData)
        {
            return WriteResponse(result, null, null);
        }

        public static ISmartResponse<T> WriteResponse<T>(this T result, string message)
        {
            return WriteResponse(result, message, null);
        }

        public static ISmartResponse<T> WriteResponse<T>(this T result, string message, Dictionary<string, object> additionalData)
        {
            return WriteResponse(result, message, ResponseStatusCode.OK, additionalData);
        }

        public static ISmartResponse<T> WriteResponse<T>(this T result, string message, ResponseStatusCode statusCode)
        {
            return WriteResponse(result, message, statusCode, null);
        }

        public static ISmartResponse<T> WriteResponse<T>(this T result, string message, ResponseStatusCode statusCode, Dictionary<string, object> additionalData)
        {
            return new SmartResponse<T> { Response = result, SuccessMessage = message, ResponseStatusCode = statusCode, AdditionalData = additionalData };
        }
        #endregion


        #region Negative Results
        public static ISmartResponse<T> WriteErrorResponse<T>(string errorMessage)
        {
            return WriteErrorResponse<T>(DefaultValidationStatusCode, DefaultValidationErrorType, errorMessage);
        }
        public static ISmartResponse<T> WriteErrorResponse<T>(string errorMessage, Dictionary<string, object> additionalData)
        {
            return WriteErrorResponse<T>(DefaultValidationStatusCode, DefaultValidationErrorType, errorMessage, additionalData);
        }

        public static ISmartResponse<T> WriteErrorResponse<T>(ErrorType errorType, string errorMessage)
        {
            return WriteErrorResponse<T>(DefaultValidationStatusCode, errorType, errorMessage);
        }

        public static ISmartResponse<T> WriteErrorResponse<T>(ErrorType errorType, string errorMessage, Dictionary<string, object> additionalData)
        {
            return WriteErrorResponse<T>(DefaultValidationStatusCode, errorType, errorMessage, additionalData);
        }

        public static ISmartResponse<T> WriteErrorResponse<T>(ResponseStatusCode statusCode, string errorMessage)
        {
            return WriteErrorResponse<T>(statusCode, DefaultValidationErrorType, errorMessage);
        }

        public static ISmartResponse<T> WriteErrorResponse<T>(ResponseStatusCode statusCode, string errorMessage, Dictionary<string, object> additionalData)
        {
            return WriteErrorResponse<T>(statusCode, DefaultValidationErrorType, errorMessage, additionalData);
        }

        public static ISmartResponse<T> WriteErrorResponse<T>(ResponseStatusCode statusCode, ErrorType errorType, string errorMessage)
        {
            return WriteErrorResponse<T>(new SmartError(errorMessage, errorType).SmartErrorList, statusCode);
        }

        public static ISmartResponse<T> WriteErrorResponse<T>(ResponseStatusCode statusCode, ErrorType errorType, string errorMessage, Dictionary<string, object> additionalData)
        {
            return WriteErrorResponse<T>(new SmartError(errorMessage, errorType).SmartErrorList, statusCode, additionalData);
        }

        public static ISmartResponse<T> WriteErrorResponse<T>(List<SmartError> errorList, ResponseStatusCode statusCode)
        {
            return WriteErrorResponse<T>(errorList, statusCode, null);
        }

        public static ISmartResponse<T> WriteErrorResponse<T>(List<SmartError> errorList, ResponseStatusCode statusCode, Dictionary<string, object> additionalData)
        {
            return new SmartResponse<T> { Errors = errorList, ResponseStatusCode = statusCode, AdditionalData = additionalData };
        }

        public static ISmartResponse WriteErrorResponse(string errorMessage)
        {
            return WriteErrorResponse(DefaultValidationStatusCode, DefaultValidationErrorType, errorMessage);
        }

        public static ISmartResponse WriteErrorResponse(string errorMessage, Dictionary<string, object> additionalData)
        {
            return WriteErrorResponse(DefaultValidationStatusCode, DefaultValidationErrorType, errorMessage, additionalData);
        }

        public static ISmartResponse WriteErrorResponse(ErrorType errorType, string errorMessage)
        {
            return WriteErrorResponse(DefaultValidationStatusCode, errorType, errorMessage);
        }

        public static ISmartResponse WriteErrorResponse(ErrorType errorType, string errorMessage, Dictionary<string, object> additionalData)
        {
            return WriteErrorResponse(DefaultValidationStatusCode, errorType, errorMessage, additionalData);
        }

        public static ISmartResponse WriteErrorResponse(ResponseStatusCode statusCode, string errorMessage)
        {
            return WriteErrorResponse(statusCode, DefaultValidationErrorType, errorMessage);
        }

        public static ISmartResponse WriteErrorResponse(ResponseStatusCode statusCode, string errorMessage, Dictionary<string, object> additionalData)
        {
            return WriteErrorResponse(statusCode, DefaultValidationErrorType, errorMessage, additionalData);
        }

        public static ISmartResponse WriteErrorResponse(ResponseStatusCode statusCode, ErrorType errorType, string errorMessage)
        {
            return WriteErrorResponse(new SmartError(errorMessage, errorType).SmartErrorList, statusCode);
        }

        public static ISmartResponse WriteErrorResponse(ResponseStatusCode statusCode, ErrorType errorType, string errorMessage, Dictionary<string, object> additionalData)
        {
            return WriteErrorResponse(new SmartError(errorMessage, errorType).SmartErrorList, statusCode, additionalData);
        }

        public static ISmartResponse WriteErrorResponse(List<SmartError> errorList, ResponseStatusCode statusCode)
        {
            return WriteErrorResponse(errorList, statusCode, null);
        }

        public static ISmartResponse WriteErrorResponse(List<SmartError> errorList, ResponseStatusCode statusCode, Dictionary<string, object> additionalData)
        {
            return new SmartResponse<int> { Errors = errorList, ResponseStatusCode = statusCode, AdditionalData = additionalData };
        }
        #endregion

        #region Exception Results
        public static ISmartResponse WriteException(this Exception ex)
        {
            return WriteException<int>(ex);
        }

        public static ISmartResponse<T> WriteException<T>(this Exception ex)
        {
            var errors = new List<string>();
            if (ex is DbEntityValidationException)
                errors.AddRange(ex.ExtractEntityValidationErrors());
            errors.AddRange(ex.ExtractErrors());
            var errorType = ex is SmartResponseException ? (ex as SmartResponseException).ErrorType : FatalValidationErrorType;
            var error = new SmartError(errors, ex.ExtractStackTrace(), ex.TargetSite.Name, errorType);
            return new SmartResponse<T> { Errors = new List<SmartError> { error }, ResponseStatusCode = FatalValidationStatusCode };
        }
        #endregion

        public static List<string> ExtractErrors<TException>(this TException ex) where TException : Exception
        {
            return ExtractInfo(ex, (exc) => exc.Message);
        }

        public static List<string> ExtractStackTrace<TException>(this TException ex) where TException : Exception
        {
            return ExtractInfo(ex, (exc) => exc.StackTrace);
        }

        public static List<string> ExtractEntityValidationErrors(this Exception ex)
        {
            if (ex is DbEntityValidationException)
                return ExtractInfo(ex as DbEntityValidationException, (exc) => string.Join("\n", exc.EntityValidationErrors.SelectMany(s => s.ValidationErrors.Select(ss => $"{ss.PropertyName}: {ss.ErrorMessage}"))));
            return new List<string>();
        }

        public static List<string> ExtractInfo<TException>(this TException ex, Func<TException, string> propertyGetter) where TException : Exception
        {
            var errors = new List<string>();
            errors.AddRange(propertyGetter?.Invoke(ex).Split('\n'));

            while (ex.InnerException != null)
            {
                if (ex.InnerException is TException)
                    errors.AddRange(propertyGetter?.Invoke(ex.InnerException as TException).Split('\n'));
            }

            return errors;
        }
    }
}
