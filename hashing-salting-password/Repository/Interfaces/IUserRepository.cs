using hashing_salting_password.Models;

namespace hashing_salting_password.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User model);
        Task<User> UpdateUser(User model);
        Task<bool> DeleteUser(int id);
    }
}