using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;

namespace InnoGotchiWebAPI.Mapper
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap <AddFarmToUserDTO,Farm> ().ReverseMap();
        }
    }
}
