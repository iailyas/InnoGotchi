using AutoMapper;
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Domain.Service;
using InnoGotchiWebAPI.Domain.Service.Interfaces;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using InnoGotchiWebAPI.Mapper;
using InnoGotchiWebAPI.Mapper.Commands;
using Moq;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

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
            mockRepo.Setup(x => x.FindAll()).ReturnsAsync(value: collaborations);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CollaborationProfile());
            });
            var mapper = mockMapper.CreateMapper();

            ICollaborationService collaborationService = new CollaborationService(mockRepo.Object, mapper);
            // Act
            var result = collaborationService.FindAll();
            var collaborationsCommand = mapper.Map<IEnumerable<CollaborationCommand>>(collaborations);
            // Assert
            Assert.Equal(collaborationsCommand, result.Result);

        }

        [Fact]
        public void Get_ShouldReturnCollaboration_WhenCollaborationExists()
        {
            //Arrange 
            var collaboration = GetCollaboration();
            Mock<ICollaborationRepository> mockRepo = new Mock<ICollaborationRepository>();
            mockRepo.Setup(x => x.FindById(1)).ReturnsAsync(value: collaboration);
            var mockMapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CollaborationProfile());
            });
            var mapper = mockMapper.CreateMapper();

            ICollaborationService applicationService = new CollaborationService(mockRepo.Object, mapper);
            // Act
            var result = applicationService.FindById(1);
            var collaborations = mapper.Map<CollaborationCommand>(collaboration);
            // Assert
            Assert.Equal(collaborations, result.Result);
        }
        //[Fact]
        //public void CreateCollaboration_ShouldReturnAddedCollaboration()
        //{
        //    //Arrange 
        //    //AddApplicationCommand applicationCommand = GetApplicationCommand();
        //    Collaboration collaboration = GetCollaboration();
        //    AddFarmToUserDTO farmToUser = FarmToUserDTO();
        //    Mock<ICollaborationRepository> mockCollaborationRepo = new Mock<ICollaborationRepository>();
        //    mockCollaborationRepo.Setup(x => x.FindById(1)).ReturnsAsync(value:collaboration);
        //    Mock<IUserRepository> mockRepo = new Mock<IUserRepository>();
        //    mockRepo.Setup(x => x.AddFarmToUser(1, farmToUser));
        //    var mockMapper = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new CollaborationProfile());
        //    });
        //    var mapper = mockMapper.CreateMapper();

        //    IUserService userService = new UserService(mockRepo.Object, mapper);
        //    ICollaborationService collaborationService = new CollaborationService(mockCollaborationRepo.Object, mapper);
        //    // Act
        //    userService.AddCollaborationToUser
        //    var result = userService.GetCollaboration(1).First();
        //    var addedApplication = collaborationService.FindById(1);
        //    // Assert
        //    Assert.Equal(addedApplication.Result, result);
        //}
        //[Fact]
        //public async Task DeleteCollaboration_ShouldReturnAddedCollaboration()
        //{
        //    //Arrange 
        //    var collaboration = GetCollaboration();
        //    //AddApplicationCommand applicationCommand = GetApplicationCommand();
        //    //Application application = GetApplication();
        //    Mock<ICollaborationRepository> mockRepo = new Mock<ICollaborationRepository>();
        //    mockRepo.Setup(x => x.Delete(1));
        //    var mockMapper = new MapperConfiguration(cfg =>
        //    {
        //        cfg.AddProfile(new CollaborationProfile());
        //    });
        //    var mapper = mockMapper.CreateMapper();

        //    ICollaborationService collaborationService = new CollaborationService(mockRepo.Object, mapper);
        //    // Act
            
        //    var result = collaborationService.Delete(1);
        //    //var addedApplication = applicationService.GetAsync(1);
        //    // Assert
        //    Assert.DoesNotContain(result.ToString(), mapper.Map<IEnumerable<CollaborationCommand>>(collaboration).ToString());
        //}
        private IEnumerable<Collaboration> GetCollaborations()
        {

            List<Collaboration> Collaborations = new List<Collaboration>()
            {

    new Collaboration()
    {
        Id = 1,
        Name = "Ilya",
        Keyword="Route66",
        Route = "1-3"

    },
    new Collaboration()
    {
        Id=2,
       Name = "Anton",
        Keyword="Route66",
        Route = "1-2"
    },
    new Collaboration()
    {
        Id=3,
        Name = "Andrey",
        Keyword="Route66",
        Route = "1-4"
    }

    };

            return Collaborations;
        }
        private Collaboration GetCollaboration()
        {


            var collaboration = new Collaboration()
            {
                Id = 1,
                Name = "Ilya",
                Keyword = "Route66",
                Route = "1-3"

            };

            return collaboration;
        }
        private AddFarmToUserDTO FarmToUserDTO()
        {


            var addFarmToUserDTO = new AddFarmToUserDTO()
            {
                Name = "Ilya",
                Dead_pets_count = 1,
                Alive_pets_count = 1,
                Average_feeding_period = 1,
                Average_thirst_quenching = 1,
                Average_pet_happiness = 1,
                Average_pets_age = 1

            };

            return addFarmToUserDTO;
        }
        private User GetUser()
        {
            var user = new User()
            {
                Id = 1,
                First_Name = "Ilya",
                Last_Name = "Kuzmenkow",
                Role = "User",
                Email = "aaa@mail.net",
                Avatar = "111.jpg"
            };
            return user;
        }
    }

}


