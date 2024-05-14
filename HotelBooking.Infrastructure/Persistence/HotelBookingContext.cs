using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Persistence;

public partial class HotelBookingContext : DbContext
{
    private readonly SeedData _seeder;

    public HotelBookingContext() { }

    public HotelBookingContext(DbContextOptions<HotelBookingContext> options, SeedData seeder) : base(options)
    {
        _seeder = seeder;
    }

    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<User> Users { get; set; }

    #region Configure entity mappings and relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookingConfiguration());

        // _seeder.Seed(modelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }
    #endregion

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
