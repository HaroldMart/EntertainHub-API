using Data;
using Data.Models;
using Data.Models.Content;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class CharacterService : Repo<Character>
    {
        public CharacterService(LibraryContext dbcontext) : base(dbcontext) { }

        public override async Task<IEnumerable<Character>> GetAll()
        {
            return (IEnumerable<Character>)EntrySet.AsNoTracking().Select(p => new Character
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
            }).ToListAsync();
        }
        public override async Task<Character> Get(int id)
        {
            return (Character)EntrySet.AsNoTracking().Select(p => new Character
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                IdEntertainment = p.IdEntertainment,
            });
        }
    }
}
