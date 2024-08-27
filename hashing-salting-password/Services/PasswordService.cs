using System.Security.Cryptography;
using hashing_salting_password.Services.Interfaces;

namespace hashing_salting_password.Services
{
    public class PasswordService : IPasswordService
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Iteration = 10000;
        public (byte[] passwordHash, byte[] salt) CreatePasswordHash(string password)
        {
            byte[] salt = GenerateSalt(SaltSize);
            byte[] hash = HashPassword(password, salt);
            return (hash, salt);
        }

        private static byte[] GenerateSalt(int size)
        {
            byte[] salt = new byte[size];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        private static byte[] HashPassword(string password, byte[] salt)
        {
            using(var pdkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(
                password, 
                salt, 
                Iteration, 
                System.Security.Cryptography.HashAlgorithmName.SHA256))
            {
                return pdkdf2.GetBytes(HashSize);
            }
        }
    }
}