namespace HotelBooking.Domain.DTOs.Response.Common
{
    public class CommonErrorResponse
    {
        public string? Code { get; set; }
        public string Message { get; set; }
        public string? StackTrace { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
