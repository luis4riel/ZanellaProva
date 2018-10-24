using Newtonsoft.Json;
using System;
using Zanella.MF7.Dominio.Exceptions;

namespace Zanella.MF7.WebAPI.Exceptions
{
    public class ExceptionPayload
    {
        public int ErrorCode { get; set; }

        [JsonIgnore]
        public Exception Exception { get; set; }

        public string ErrorMessage { get; set; }

        public static ExceptionPayload New<T>(T exception) where T : Exception
        {
            int errorCode;
            if (exception is BusinessException)
                errorCode = (exception as BusinessException).ErrorCode.GetHashCode();
            else
                errorCode = ErrorCodes.Unhandled.GetHashCode();
            return new ExceptionPayload
            {
                ErrorCode = errorCode,
                ErrorMessage = exception.Message,
                Exception = exception,
            };
        }
    }
}