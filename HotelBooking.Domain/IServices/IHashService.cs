namespace HotelBooking.Domain.IServices
{
    public interface IHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
