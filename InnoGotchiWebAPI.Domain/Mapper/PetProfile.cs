using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Mapper
{
    public class PetProfile:Profile
    {
        public void PetMapProfile()
        {
            CreateMap<Pet, PetCommand>().ReverseMap();
            CreateMap<PetCommand, AddPetToFarmDTO>().ReverseMap();
            CreateMap<Pet, AddPetToFarmDTO>().ReverseMap();
        }
    }
}
