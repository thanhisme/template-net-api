namespace HotelBooking.Domain.Entities
{
    public class Room
    {
        public enum RoomType
        {
            Single,
            Double,
            Suite
        }

        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public RoomType Type { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
