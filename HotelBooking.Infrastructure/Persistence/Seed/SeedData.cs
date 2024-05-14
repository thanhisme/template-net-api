using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Persistence.FileManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelBooking.Infrastructure.Persistence.Seed;

public class SeedData
{
    private readonly IFileManager _fileManager;
    private readonly IConfiguration _configuration;

    public SeedData(IFileManager fileManager, IConfiguration configuration)
    {
        _fileManager = fileManager;
        _configuration = configuration;
    }

    public void Seed(ModelBuilder modelBuilder)
    {
        var users = ReadEntitiesFromJson<User>(nameof(User)).Result;
        var rooms = ReadEntitiesFromJson<Room>(nameof(Room)).Result;

        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Room>().HasData(rooms);
    }

    private async Task<List<TEntity>> ReadEntitiesFromJson<TEntity>(string entityName) where TEntity : class
    {
        string section = _configuration[$"DataPath:{entityName}s"] ?? "";

        if (string.IsNullOrEmpty(section))
        {
            return new();
        }

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, section);

        var entities = await _fileManager.ReadFile<TEntity>(filePath);

        return entities;
    }
}
