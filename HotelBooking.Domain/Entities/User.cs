namespace HotelBooking.Domain.Entities
{
    public class User
    {
        public enum UserRole
        {
            Receptionist,
            Admin,
            Customer
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public UserRole Role { get; set; }

        public virtual List<Booking> Bookings { get; set; }
    }
}
