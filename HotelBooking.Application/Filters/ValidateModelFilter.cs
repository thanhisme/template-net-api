using HotelBooking.Domain.Constants;
using HotelBooking.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HotelBooking.Application.Filters
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        // This method is called when validation fails
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                var errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                throw new AppException(HttpStatusCode.BadRequest, HttpErrorMessage.ValidationError, errors);
            }
        }
    }
}
