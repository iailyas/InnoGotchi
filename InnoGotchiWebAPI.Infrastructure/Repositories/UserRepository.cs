
using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private MainDbContext mainDbContext;


        public UserRepository(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IEnumerable<Collaboration> GetCollaboration(int userId) 
        {
            var collaborations = mainDbContext.Collaboration.Where(a => a.UserId==userId);
            return collaborations;
        }
        public async Task AddCollaborationToUser(int id, AddCollaborationToUserDTO collaborationDTO)
        {
            var user = await FindById(id);
            if (user == null)
            {
                throw new Exception("Incorrect User");
            }
            var collaboration = new Collaboration
            {
                Name = collaborationDTO.Name,
                Keyword = collaborationDTO.Keyword,
                Route = collaborationDTO.Route,
                UserId = id
            };
            await mainDbContext.Collaboration.AddAsync(collaboration);
            //await mainDbContext.SaveChangesAsync();
            //var currentCollaboration=await mainDbContext.Collaboration.SingleAsync(c => c.Name == collaboration.Name);
            //User.CollaborationId = currentCollaboration.Id;
            //mainDbContext.User.Update(User);
            await mainDbContext.SaveChangesAsync();
        }

        public async Task AddFarmToUser(int id, AddFarmToUserDTO addFarmToUserDTO)
        {
            var user = await FindById(id);
            if (user == null)
            {
                throw new Exception("Incorrect User");
            }
            var farm = new Farm
            {
                Name = addFarmToUserDTO.Name,
                Dead_pets_count = addFarmToUserDTO.Dead_pets_count,
                Alive_pets_count = addFarmToUserDTO.Alive_pets_count,
                Average_feeding_period = addFarmToUserDTO.Average_pets_age,
                Average_thirst_quenching = addFarmToUserDTO.Average_thirst_quenching,
                Average_pet_happiness = addFarmToUserDTO.Average_pet_happiness,
                Average_pets_age = addFarmToUserDTO.Average_pets_age,
                UserId = id
            };
            await mainDbContext.Farm.AddAsync(farm);
            await mainDbContext.SaveChangesAsync();
        }

        public async Task<String> Create(UserDTO entity, IWebHostEnvironment webHostEnvironment)
        {


            try
            {
                string path = webHostEnvironment.ContentRootPath + "\\Uploads\\";
                using (FileStream fs = System.IO.File.Create(path + entity.Avatar.FileName))
                {
                    await entity.Avatar.CopyToAsync(fs);
                    fs.Flush();
                    var user = new User
                    {
                        First_Name = entity.First_Name,
                        Last_Name = entity.Last_Name,
                        Role = entity.Role,
                        Email = entity.Email,
                        Avatar = entity.Avatar.FileName
                    };
                    await mainDbContext.AddAsync(user);
                    await mainDbContext.SaveChangesAsync();
                    return "done";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task Delete(int id)
        {
            var user = FindById(id);
            mainDbContext.Remove(user);
            await mainDbContext.SaveChangesAsync();

        }

        public async Task DeleteByName(string lastName)
        {
            var user = FindByName(lastName);
            mainDbContext.Remove(user);
            await mainDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            return await mainDbContext.User.Include(c => c.Collaborations).Include(f => f.Farms).AsNoTracking().ToListAsync();
        }

        public async Task<User> FindById(int id)
        {
            return await mainDbContext.User.AsNoTracking().SingleAsync(a => a.Id == id);
        }

        public async Task<User> FindByName(string lastName)
        {
            return await mainDbContext.User.AsNoTracking().SingleAsync(a => a.Last_Name == lastName);
        }

        public async Task Update(User user)
        {
            mainDbContext.Update(user);
            await mainDbContext.SaveChangesAsync();
        }
    }
}
