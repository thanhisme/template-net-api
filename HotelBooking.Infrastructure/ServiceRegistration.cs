using HotelBooking.Domain;
using HotelBooking.Infrastructure.Persistence;
using HotelBooking.Infrastructure.Persistence.FileManager;
using HotelBooking.Infrastructure.Persistence.Seed;
using HotelBooking.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBooking.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            AppSettingConfiguration appConfig
        )
        {
            services
                .RegisterDbContext(appConfig)
                .RegisterUnitOfWork()
                .RegisterDataAccess();

            return services;
        }

        #region Register DbContext
        private static IServiceCollection RegisterDbContext(
            this IServiceCollection services,
            AppSettingConfiguration appConfig
        )
        {
            services.AddDbContext<HotelBookingContext>(options =>
                options.UseSqlServer(appConfig?.ConnectionStrings.DefaultConnection ?? "")
            );

            return services;
        }
        #endregion

        #region Register UnitOfWork
        private static IServiceCollection RegisterUnitOfWork(
            this IServiceCollection services
        )
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
        #endregion

        #region Register Data Access
        private static IServiceCollection RegisterDataAccess(this IServiceCollection services)
        {
            services.AddSingleton<IFileManager, JsonFileManager>();

            services.AddTransient<SeedData>();

            // repository here

            return services;
        }
        #endregion
    }
}
