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
    public class SerieService : Repo<Serie>
    {
        public SerieService(LibraryContext dbcontext) : base(dbcontext) { }

        public override Task<IEnumerable<Serie>> GetAll()
        {
            var data = (IEnumerable<Serie>)EntrySet.AsNoTracking().Select(p => new Serie
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                Release = p.Release,
                Date = p.Date,
                Seasons = p.Seasons,
                Director = p.Director,
                Episodes = p.Episodes,
                Characters = (ICollection<Data.Models.Character>)
           p.Characters
           .Select(c => new
           {
               c.Id,
               c.Name,
               c.Description
           }).ToList()
            }).ToListAsync();

            return (Task<IEnumerable<Serie>>)data;
        }
        public override async Task<Serie> Get(int id)
        {
            var data = (Serie)EntrySet.AsNoTracking().Select(p => new Serie
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                Release = p.Release,
                Date = p.Date,
                Seasons = p.Seasons,
                Director = p.Director,
                Episodes = p.Episodes,
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
