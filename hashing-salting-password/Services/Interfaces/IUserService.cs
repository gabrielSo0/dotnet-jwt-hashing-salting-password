using hashing_salting_password.DTO;
using hashing_salting_password.Models;

namespace hashing_salting_password.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(UserDTO user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}