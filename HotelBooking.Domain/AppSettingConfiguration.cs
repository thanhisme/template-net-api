using Newtonsoft.Json;

namespace HotelBooking.Domain
{
    public class AppSettingConfiguration
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public DataPath DataPath { get; set; }
        public Jwt Jwt { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class DataPath
    {
        public string ToDoTasks { get; set; }
        public string Users { get; set; }
    }

    public class Jwt
    {
        public string SecretKey { get; set; }
        public int ExpiresInMinutes { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        [JsonProperty("Microsoft.AspNetCore")]
        public string MicrosoftAspNetCore { get; set; }
    }
}
