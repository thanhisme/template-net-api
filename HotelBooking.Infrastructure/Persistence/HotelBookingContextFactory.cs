using HotelBooking.Infrastructure.Persistence.FileManager;
using HotelBooking.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelBooking.Infrastructure.Persistence
{
    public class HotelBookingContextFactory : IDesignTimeDbContextFactory<HotelBookingContext>
    {
        private const string DEFAULT_ENV = "Development";

        public HotelBookingContext CreateDbContext(string[] args)
        {
            string environment = args.FirstOrDefault() ?? DEFAULT_ENV;

            var fileManager = new JsonFileManager();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings{"." + environment}.json")
                .Build();
            var seeder = new SeedData(fileManager, configuration);
            var optionsBuilder = new DbContextOptionsBuilder<HotelBookingContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new HotelBookingContext(optionsBuilder.Options, seeder);
        }
    }
}
