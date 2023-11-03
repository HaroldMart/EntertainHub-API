using Data.Models.Content;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Services
{
    public class ComicService : Repo<Comic>
    {
        public ComicService(LibraryContext dbcontext) : base(dbcontext) { }

        public override Task<IEnumerable<Comic>> GetAll()
        {
            var data = (IEnumerable<Comic>)EntrySet.AsNoTracking().Select(p => new Comic
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                Release = p.Release,
                Date = p.Date,
                Pages = p.Pages,
                Author = p.Author,
                Characters = (ICollection<Data.Models.Character>)
                p.Characters
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Description
                }).ToList()
            }).ToListAsync();

            return (Task<IEnumerable<Comic>>)data;
        }
        public override async Task<Comic> Get(int id)
        {
            var data = (Comic)EntrySet.AsNoTracking().Select(p => new Comic
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                Release = p.Release,
                Date = p.Date,
                Pages = p.Pages,
                Author = p.Author,
                Characters = (ICollection<Data.Models.Character>)
                p.Characters
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Description
                }).ToList()
            });

            return data;
        }
    }
}
