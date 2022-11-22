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

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void GetAll_ShouldReturnAplications_WhenAplicationsExists()
        {
            //Arrange 
            var collaborations = GetCollaborations();
            Mock<ICollaborationRepository> mockRepo = new Mock<ICollaborationRepository>();
            mockRepo.Setup(x => x.FindAll()).ReturnsAsync(value: collaborations);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMapProfile());
            });
            var mapper = mockMapper.CreateMapper();

            ICollaborationService applicationService = new CollaborationService(mockRepo.Object);
            // Act
            var result = applicationService.FindByName();

            // Assert
            Assert.Equal(applications, result.Result);

        }

        private IEnumerable<AddCollaborationToUserDTO> GetCollaborations()
        {
            var applications = new AddCollaborationToUserDTO()
            {
                Name = "MyApplication",
                Keyword = "Killer",
                Route = "Doctor-Killer"

            };

            var application= new AddCollaborationToUserDTO()
             {
                Name = "MyApplication2",
                Keyword = "ui",
                Route = "killer-doctor"

            };
            List<AddCollaborationToUserDTO> addCollaborations = new List<AddCollaborationToUserDTO>();
            addCollaborations.Add(applications);
            addCollaborations.Add(application);

            return addCollaborations;
        }
    }
}