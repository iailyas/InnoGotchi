﻿using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace InnoGotchiWebAPI.Infrastructure.Repositories
{
    public class LookRepository: ILookRepository
    {
        private MainDbContext context;

        public LookRepository(MainDbContext context)
        {
            this.context = context;
        }

        public async Task Delete(int id)
        {
            var look = FindById(id);
            context.Remove(look);
            await context.SaveChangesAsync();
        }

        //public async Task DeleteByName(string lookName)
        //{
        //    var look = FindByName(lookName);
        //    context.Remove(look);
        //    await context.SaveChangesAsync();
        //}

        public async Task<IEnumerable<Look>> FindAll()
        {
            return await context.Look.AsNoTracking().ToListAsync();
        }

        public async Task<Look> FindById(int id)
        {
            return await context.Look.AsNoTracking().SingleAsync(b => b.Id == id);
        }

        public async Task Update(Look look)
        {
            context.Update(look);
            await context.SaveChangesAsync();
        }
    }
}
