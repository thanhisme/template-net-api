namespace HotelBooking.Domain.Constants
{
    public static class HttpErrorMessage
    {
        static Dictionary<string, string> ErrorMessages = new()
        {
            { PasswordConfirmNotMatch, "Password and password confirm do not match" },
            { AccountAlreadyTaken, "Account is already taken" },
            { ResourceNotFound, "{0} not found" },
            { PasswordIsIncorrect, "Password is incorrect" },
            { InvalidResetPasswordToken, "Invalid reset password token" },
            { ResetTokenHasExpired, "Reset token has expired" },
            { UnauthenticatedUserOnly, "Unauthenticated user only" },
            { AuthenticationUserOnly, "You must be authenticated to access this resource" },
            { AccessDenied, "Access denied" },
            { ValidationError, "Validation error" }
        };

        public const string PasswordConfirmNotMatch = "PASSWORD_CONFIRM_NOT_MATCH";
        public const string AccountAlreadyTaken = "ACCOUNT_ALREADY_TAKEN";
        public const string ResourceNotFound = "RESOURCE_NOT_FOUND";
        public const string PasswordIsIncorrect = "PASSWORD_IS_INCORRECT";
        public const string InvalidResetPasswordToken = "INVALID_RESET_PASSWORD_TOKEN";
        public const string ResetTokenHasExpired = "RESET_TOKEN_HAS_EXPIRED";
        public const string UnauthenticatedUserOnly = "UNAUTHENTICATED_USER_ONLY";
        public const string AuthenticationUserOnly = "AUTHENTICATION_USER_ONLY";
        public const string AccessDenied = "ACCESS_DENIED";
        public const string ValidationError = "VALIDATION_ERROR";

        public static string GetErrorMessage(string key)
        {
            if (ErrorMessages.TryGetValue(key, out string message))
            {
                return message;
            }
            else
            {
                return "Error message not found";
            }
        }
    }
}
