using AutoMapper;
using hashing_salting_password.DTO;
using hashing_salting_password.Models;
using hashing_salting_password.Repository.Interfaces;
using hashing_salting_password.Services.Interfaces;

namespace hashing_salting_password.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;

        public UserService(
            IUserRepository userRepository, 
            IMapper mapper,
            ITokenService tokenService,
            IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
            _passwordService = passwordService;
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

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            try
            {
                (byte[] passwordHash, byte[] salt) = _passwordService.CreatePasswordHash(userDTO.Password);

                var user = _mapper.Map<UserDTO, User>(userDTO);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = salt;
                
                user = await _userRepository.Create(user);

                userDTO = _mapper.Map<User, UserDTO>(user);
                userDTO.Token = _tokenService.GenerateToken(userDTO);

                return userDTO;
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