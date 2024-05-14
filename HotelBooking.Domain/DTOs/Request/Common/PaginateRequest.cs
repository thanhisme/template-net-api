namespace HotelBooking.Domain.DTOs.Request.Common
{
    public class PaginateRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
