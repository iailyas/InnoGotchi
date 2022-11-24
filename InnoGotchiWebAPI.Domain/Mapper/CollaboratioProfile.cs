using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;

namespace InnoGotchiWebAPI.Mapper
{
    public class CollaborationProfile :Profile
    {
        public void CollaborationMapProfile()
        {
            CreateMap<Collaboration, CollaborationCommand>().ReverseMap();
            CreateMap<CollaborationCommand, AddCollaborationToUserDTO>().ReverseMap();
            CreateMap<Collaboration, AddCollaborationToUserDTO>().ReverseMap();
        }
        
    }
}
