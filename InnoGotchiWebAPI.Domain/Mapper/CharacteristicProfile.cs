using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Mapper
{
    public class CharacteristicProfile:Profile
    {
        public void CharacteristicMapProfile()
        {
            CreateMap<Characteristic, CharacteristicCommand>().ReverseMap();
            CreateMap<CharacteristicCommand, AddCharacteristicToPetDTO>().ReverseMap();
            CreateMap<Characteristic, AddCharacteristicToPetDTO>().ReverseMap();
        }
    }
}
