namespace HotelBooking.Domain.DTOs.Response.Common
{
    public class CommonSuccessResponse
    {
        public int? TotalRecords { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}
