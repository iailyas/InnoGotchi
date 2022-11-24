using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Mapper
{
    public class FarmProfile:Profile
    {
        public void FarmMapProfile()
        {
            CreateMap<Farm, FarmCommand>().ReverseMap();
            CreateMap<FarmCommand, AddFarmToUserDTO>().ReverseMap();
            CreateMap<Farm, AddFarmToUserDTO>().ReverseMap();
        }
    }
}
