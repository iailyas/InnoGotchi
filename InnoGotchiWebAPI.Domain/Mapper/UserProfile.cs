using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Mapper
{
    public class UserProfile:Profile
    {
        public void UserMapProfile()
        {
            CreateMap<User, UserCommand>().ReverseMap();
            CreateMap<UserCommand, UserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
