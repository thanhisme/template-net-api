using HotelBooking.Domain.IServices;
using HotelBooking.Services.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBooking.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IJwtService, JwtService>();
            services.AddTransient<IHashService, SHA256HashService>();
            services.AddScoped<IHttpContextService, HttpContextService>();

            services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            return services;
        }

        public static IServiceCollection RegisterValidator(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            // services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();

            return services;
        }
    }
}
