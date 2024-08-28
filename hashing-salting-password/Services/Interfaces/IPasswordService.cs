namespace hashing_salting_password.Services.Interfaces
{
    public interface IPasswordService
    {
        (byte[] passwordHash, byte[] salt) CreatePasswordHash(string password);
        public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
    }
}