
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class CharacteristicRepository : ICharacteristicRepository
    {
        private MainDbContext context;

        public CharacteristicRepository(MainDbContext context)
        {
            this.context = context;
        }

        public async Task Delete(int id)
        {
            var characteristic = FindById(id);
            context.Remove(characteristic);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Characteristic>> FindAll()
        {
            return await context.Characteristic.AsNoTracking().ToListAsync();
        }

        public async Task<Characteristic> FindById(int id)
        {
            return await context.Characteristic.AsNoTracking().SingleAsync(b => b.Id == id);
        }      

        public async Task Update(Characteristic characteristic)
        {
            context.Update(characteristic);
            await context.SaveChangesAsync();
        }
    }
}
