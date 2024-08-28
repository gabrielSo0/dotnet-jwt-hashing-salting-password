using hashing_salting_password.Models;

namespace hashing_salting_password.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByUserName(string userName);
        Task<User> Create(User model);
        Task<User> Update(User model);
        Task<bool> Delete(int id);
    }
}