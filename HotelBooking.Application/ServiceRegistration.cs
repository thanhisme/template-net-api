using HotelBooking.Application.Filters;
using HotelBooking.Application.Policies;
using HotelBooking.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelBooking
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddWebApiServices(
            this IServiceCollection services,
            AppSettingConfiguration appConfig
        )
        {
            services.AddHttpContextAccessor(); // Đăng ký IHttpContextAccessor

            services.RegisterAuthentication(appConfig);

            services.RegisterAuthorization();

            services.RegisterController();

            services.RegisterSwagger();

            return services;
        }

        #region Register Controller
        private static IServiceCollection RegisterController(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidateModelFilter>();
                options.Filters.Add<ApiResponseFormatFilter>();
            });

            services.AddScoped<ValidateModelFilter>();

            return services;
        }
        #endregion

        #region Register Authentication
        private static IServiceCollection RegisterAuthentication(
            this IServiceCollection services,
            AppSettingConfiguration appConfig
        )
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appConfig.Jwt.SecretKey)),
                        };
                    });

            return services;
        }
        #endregion

        #region Register Authorization
        private static IServiceCollection RegisterAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
                    {
                        options.AddPolicy("IsAdmin", policy =>
                        {
                            policy.Requirements.Add(new IsAdminRequirement());
                            policy.RequireAuthenticatedUser();
                        });

                        options.AddPolicy("AnonymousOnly", policy =>
                        {
                            policy.Requirements.Add(new AnonymousOnlyRequirement());
                        });
                    });

            services.AddScoped<IAuthorizationHandler, IsAdminHandler>();
            services.AddScoped<IAuthorizationHandler, AnonymousOnlyHandler>();

            return services;
        }
        #endregion

        #region Register Swagger
        private static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
        #endregion
    }
}
