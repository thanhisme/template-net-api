namespace HotelBooking.Infrastructure.Persistence.FileManager
{
    public interface IFileManager
    {
        Task<List<T>> ReadFile<T>(string path);
    }
}
