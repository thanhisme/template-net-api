using HotelBooking;
using HotelBooking.Application.Middlewares;
using HotelBooking.Domain;
using HotelBooking.Infrastructure;
using HotelBooking.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

AppSettingConfiguration appConfig = builder.Configuration.Get<AppSettingConfiguration>();

builder.Services
    .AddSingleton(appConfig)
    .AddWebApiServices(appConfig)
    .AddServices()
    .AddInfrastructure(appConfig);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthentication(); // validate token

app.UseAuthorization(); // ki?m tra quy?n

app.MapControllers(); // Routing

app.Run();

