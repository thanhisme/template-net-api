using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain.Entities
{
    public class Booking
    {
        public enum BookingStatus
        {
            Pending,
            Confirmed,
            Cancelled
        }

        public int Id { get; set; }
        public int UserId { get; set; }  // Foreign key to User
        public int RoomId { get; set; }  // Foreign key to Room
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string? Note { get; set; }
        public decimal PricePerNight { get; set; }
        public int NumberOfNights { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; set; }

        public virtual User User { get; set; }
        public virtual Room Room { get; set; }
    }

    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Booking> builder)
        {
            builder
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(b => b.Room)
                .WithMany()
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
