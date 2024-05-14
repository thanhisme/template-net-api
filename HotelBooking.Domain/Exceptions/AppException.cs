using HotelBooking.Domain.Constants;
using System.Net;

namespace HotelBooking.Domain.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string Code { get; }
        public List<string> Errors { get; set; } = new();

        public AppException(HttpStatusCode statusCode, string code, string? message = null)
            : base(message == null ? HttpErrorMessage.GetErrorMessage(code) : message)
        {
            StatusCode = statusCode;
            Code = code;
        }

        public AppException(HttpStatusCode statusCode, string code, List<string> errors)
            : base(HttpErrorMessage.GetErrorMessage(code))
        {
            StatusCode = statusCode;
            Code = code;
            Errors = errors;
        }

        public AppException(HttpStatusCode statusCode, string code, Exception innerException)
            : base(HttpErrorMessage.GetErrorMessage(code), innerException)
        {
            StatusCode = statusCode;
            Code = code;
        }
    }
}