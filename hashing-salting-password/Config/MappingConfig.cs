using AutoMapper;
using hashing_salting_password.DTO;
using hashing_salting_password.Models;

namespace hashing_salting_password.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => 
            {
                config.CreateMap<UserDTO, User>();
                config.CreateMap<User, UserDTO>();
            });

            return mappingConfig;
        }
    }
}