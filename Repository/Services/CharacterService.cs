using Data;
using Data.Models;
using Data.Models.Content;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Interface;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class CharacterService : Repo<Character>, IService<CharacterDto>
    {
        public CharacterService(LibraryContext dbcontext) : base(dbcontext) { }

        public ICollection<CharacterDto> GetAll()
        {
            var data = EntrySet.AsNoTracking().Select(p => new CharacterDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                IdEntertainment = p.IdEntertainment
            }).ToList();

            return data;

        }
        public CharacterDto? Get(int id)
        {
            var data = EntrySet.FirstOrDefault(i => i.Id == id);
            CharacterDto character;

            if (data != null)
            {
                character = new CharacterDto
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description,
                    IdEntertainment = data.IdEntertainment
                };

            return character;
        };

            return null;
        }
    }
}
