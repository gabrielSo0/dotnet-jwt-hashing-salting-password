using hashing_salting_password.Models;
using hashing_salting_password.Repository.Interfaces;
using hashing_salting_password.Services.Interfaces;

namespace hashing_salting_password.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAll();

                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something happended: {0}", ex);
                throw;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _userRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something happended: {0}", ex);
                throw;
            }
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                return await _userRepository.Create(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something happended: {0}", ex);
                throw;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                return await _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something happended: {0}", ex);
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                return await _userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something happended: {0}", ex);
                throw;
            }
        }
    }
}