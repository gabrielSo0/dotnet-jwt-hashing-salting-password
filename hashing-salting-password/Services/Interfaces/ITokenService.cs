using hashing_salting_password.DTO;

namespace hashing_salting_password.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO userDTO);
    }
}