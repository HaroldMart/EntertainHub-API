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
    public class MovieService : Repo<Movie>
    {
        public MovieService(LibraryContext dbcontext) : base(dbcontext) { }

        public override Task<IEnumerable<Movie>> GetAll()
        {
            var data = (IEnumerable<Movie>)EntrySet.AsNoTracking().Select(p => new Movie
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                Release = p.Release,
                Date = p.Date,
                Director = p.Director,
                Duration = p.Duration,
                Characters = (ICollection<Data.Models.Character>)
           p.Characters
           .Select(c => new
           {
               c.Id,
               c.Name,
               c.Description
           }).ToList()
            }).ToListAsync();

            return (Task<IEnumerable<Movie>>)data;
        }
        public override async Task<Movie> Get(int id)
        {
            var data = (Movie)EntrySet.AsNoTracking().Select(p => new Movie
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                Release = p.Release,
                Date = p.Date,
                Director = p.Director,
                Duration = p.Duration,
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
