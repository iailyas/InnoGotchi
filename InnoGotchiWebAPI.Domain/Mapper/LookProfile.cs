using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Mapper
{
    public class LookProfile:Profile
    {
        public void LookMapProfile()
        {
            CreateMap<Look, LookCommand>().ReverseMap();
            CreateMap<FarmCommand, AddLookToPetDTO>().ReverseMap();
            CreateMap<Look, AddLookToPetDTO>().ReverseMap();
        }
    }
}
