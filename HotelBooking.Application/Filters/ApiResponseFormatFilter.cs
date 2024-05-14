using HotelBooking.Domain.DTOs.Response.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelBooking.Application.Filters
{
    public class ApiResponseFormatFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                int? totalRecords = null;

                if (objectResult.Value is not null)
                {
                    if (objectResult.Value is ValueTuple<int, object> tuple)
                    {
                        totalRecords = tuple.Item1;
                    }
                    else if (objectResult.Value is IEnumerable<object> list)
                    {
                        totalRecords = list.Count();
                    }
                }

                var response = new CommonSuccessResponse
                {
                    TotalRecords = totalRecords,
                    Message = objectResult.StatusCode switch
                    {
                        201 => "Created",
                        204 => "No Content",
                        _ => "Success",
                    },
                    Data = objectResult.Value is int ? null : objectResult.Value
                };

                objectResult.Value = response;
            }

            base.OnResultExecuting(context);
        }
    }

}
