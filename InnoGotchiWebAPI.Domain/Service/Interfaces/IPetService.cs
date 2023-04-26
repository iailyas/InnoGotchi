﻿using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchiWebAPI.Domain.Service.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> FindAll();
        Task<Pet> FindById(int id);
        Task<Pet> FindByName(string petName);
        Task AddLookToPet(int id, AddLookToPetDTO lookToPetDTO, IWebHostEnvironment webHostEnvironment);
        Task AddCharacteristicToPet(int id, AddCharacteristicToPetDTO addCharacteristicToPetDTO);
        Task Update(Pet pet);
        Task Delete(int id);
        Task DeleteByName(string userName);
        Task<IEnumerable<Pet>> CurrentFarmPets(int farmId);
    }
}
