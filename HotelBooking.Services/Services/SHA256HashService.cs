using HotelBooking.Domain.IServices;
using System.Security.Cryptography;
using System.Text;

namespace HotelBooking.Services.Services
{
    public class SHA256HashService : IHashService
    {
        private const int SaltSize = 15;

        public string HashPassword(string password)
        {
            SHA256 hash256 = SHA256.Create();

            // Chuẩn bị random ra salt
            byte[] randomBytes = RandomNumberGenerator.GetBytes(SaltSize); // random 15 bytes
            IEnumerable<string> saltHex = randomBytes.Select(x => x.ToString("x2"));
            string salt = string.Join("", saltHex).Substring(SaltSize); // kết quả đã có salt

            string input = salt + password; // Gộp salt và password để đem di hash

            // hash với sha-256
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = hash256.ComputeHash(inputBytes);

            IEnumerable<string> hex = hash.Select(x => x.ToString("x2"));

            // Chuyển kết quả về chuỗi
            string passwordHash = string.Join("", hex);

            return passwordHash;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            SHA256 hash256 = SHA256.Create();

            // Lấy salt từ hashedPassword
            string salt = hashedPassword.Substring(0, SaltSize);

            // Gộp salt và password để hash
            string input = salt + password;
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = hash256.ComputeHash(inputBytes);

            IEnumerable<string> hex = hash.Select(x => x.ToString("x2"));

            // Chuyển kết quả về chuỗi
            string passwordHash = string.Join("", hex);

            return passwordHash == hashedPassword;
        }
    }
}
