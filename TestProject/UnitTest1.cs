using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.Repositories;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Routing;
using Moq;
using System.ComponentModel.DataAnnotations;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using AutoMapper;
using InnoGotchiWebAPI.Mapper;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void GetAll_ShouldReturnCollaborations_WhenCollaborationsExists()
        {
            //Arrange 
            var collaborations = GetCollaborations();
            Mock<ICollaborationRepository> mockRepo = new Mock<ICollaborationRepository>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CollaborationMapProfile());
            });
            var mapper = mockMapper.CreateMapper();
            var collaborationsMap =mapper.Map<List<Collaboration>>(collaborations);

            mockRepo.Setup(x => x.FindAll()).ReturnsAsync(value: collaborationsMap);
            

            ICollaborationService applicationService = new CollaborationService(mockRepo.Object);
            // Act
            var result = applicationService.FindAll();
            
            // Assert
            Assert.Equal(collaborationsMap, result.Result);

        }
        [Fact]
        public void GetByName_ShouldReturnCollaboration_WhenCollaborationExists()
        {
            //Arrange 
            var collaboration = GetCollaboration();
            Mock<ICollaborationRepository> mockRepo = new Mock<ICollaborationRepository>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CollaborationMapProfile());
            });
            var mapper = mockMapper.CreateMapper();
            var collaborationMap = mapper.Map<Collaboration>(collaboration);

            mockRepo.Setup(x => x.FindByName("MyCollaboration")).ReturnsAsync(value: collaborationMap);


            ICollaborationService applicationService = new CollaborationService(mockRepo.Object);
            // Act
            var result = applicationService.FindByName("MyCollaboration");

            // Assert
            Assert.Equal(collaborationMap, result.Result);

        }
        [Fact]
        public void GetByName_ShouldFail()
        {
            //Arrange 
            var collaboration = GetCollaboration();
            Mock<ICollaborationRepository> mockRepo = new Mock<ICollaborationRepository>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CollaborationMapProfile());
            });
            var mapper = mockMapper.CreateMapper();
            var collaborationMap = mapper.Map<Collaboration>(collaboration);

            mockRepo.Setup(x => x.FindByName("MyCollaboration")).ReturnsAsync(value: collaborationMap);


            ICollaborationService applicationService = new CollaborationService(mockRepo.Object);
            // Act
            var result = applicationService.FindByName("MyCollaboration1");

            // Assert
            Assert.NotEqual(collaborationMap, result.Result);

        }

        private IEnumerable<AddCollaborationToUserDTO> GetCollaborations()
        {
            var collaborations = new AddCollaborationToUserDTO()
            {
                Name = "MyCollaboration",
                Keyword = "Killer",
                Route = "Doctor-Killer"

            };

            var collaboration = new AddCollaborationToUserDTO()
             {
                Name = "MyCollaboration",
                Keyword = "ui",
                Route = "killer-doctor"

            };
            List<AddCollaborationToUserDTO> addCollaborations = new List<AddCollaborationToUserDTO>();
            addCollaborations.Add(collaborations);
            addCollaborations.Add(collaboration);

            return addCollaborations;
        }
        private AddCollaborationToUserDTO GetCollaboration()
        {
            var collaboration = new AddCollaborationToUserDTO()
            {
                Name = "MyCollaboration",
                Keyword = "Killer",
                Route = "Doctor-Killer"

            };


            return collaboration;
        }
    }
}