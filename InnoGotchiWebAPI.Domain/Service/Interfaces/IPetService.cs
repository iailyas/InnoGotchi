using InnoGotchiWebAPI.Domain.DTO;
using InnoGotchiWebAPI.Domain.Models;
using InnoGotchiWebAPI.Mapper.Commands;
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
        Task<IEnumerable<PetCommand>> FindAll();
        Task<PetCommand> FindById(int id);
        Task<PetCommand> FindByName(string petName);
        Task AddLookToPet(int id, AddLookToPetDTO lookToPetDTO, IWebHostEnvironment webHostEnvironment);
        Task AddCharacteristicToPet(int id, AddCharacteristicToPetDTO addCharacteristicToPetDTO);
        Task Update(PetCommand pet);
        Task Delete(int id);
        Task DeleteByName(string userName);
    }
}
