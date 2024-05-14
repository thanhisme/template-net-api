namespace HotelBooking.Domain.Constants
{
    public static class HttpSuccessMessage
    {
        static Dictionary<string, string> SuccessMessages = new()
        {
            { UserCreated, "User with account {0} has been created" },
            { PasswordReseted, "Password has been reset" },
        };

        public const string UserCreated = "USER_CREATED";
        public const string PasswordReseted = "PASSWORD_RESETED";

        public static string GetSuccessMessage(string key)
        {
            if (SuccessMessages.TryGetValue(key, out string message))
            {
                return message;
            }
            else
            {
                return "Success message not found";
            }
        }
    }
}
