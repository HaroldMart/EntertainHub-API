using Data.Models.Content;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class MangaService : Repo<Manga>
    {
        public MangaService(LibraryContext dbcontext) : base(dbcontext) { }

        public override Task<IEnumerable<Manga>> GetAll()
        {
            var data = (IEnumerable<Manga>)EntrySet.AsNoTracking().Select(p => new Manga
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

            return (Task<IEnumerable<Manga>>)data;
        }
        public override async Task<Manga> Get(int id)
        {
            var data = (Manga)EntrySet.AsNoTracking().Select(p => new Manga 
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
