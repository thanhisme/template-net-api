using Newtonsoft.Json;

namespace HotelBooking.Infrastructure.Persistence.FileManager
{
    public class JsonFileManager : IFileManager
    {
        public async Task<List<T>> ReadFile<T>(string path)
        {
            try
            {
                string json = await File.ReadAllTextAsync(path);
                var entities = JsonConvert.DeserializeObject<List<T>>(json);

                if (entities == null)
                {
                    return new();
                }

                return entities;
            }
            catch
            {
                return new();
            }
        }
    }
}
