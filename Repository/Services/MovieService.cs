using Data.Models.Content;
using Data;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Interfaces;

namespace Repository.Services
{
    public class MovieService : Repo<Movie>, IService<MovieDto>
    {
        public MovieService(LibraryContext dbcontext) : base(dbcontext) { }

        public ICollection<MovieDto> GetAll()
        {
            var data = EntrySet.AsNoTracking().Select(p => new MovieDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Release = p.Release,
                ImageUrl = p.ImageUrl,
                Date = p.Date,
                Genres = p.Genres,
                Duration = p.Duration,
                Director = p.Director,
                Characters =
           p.Characters
            .Select(c => new CharacterDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                IdEntertainment = c.IdEntertainment
            }).ToList()
            }).ToList();

            return data;
        }
        public MovieDto? Get(int id)
        {
            var data = EntrySet.Include(c => c.Characters).FirstOrDefault(i => i.Id == id);
            MovieDto movie;

            if (data != null)
            {
                movie = new MovieDto
                {
                    Id = data?.Id,
                    Name = data.Name,
                    Description = data.Description,
                    Release = data.Release,
                    ImageUrl = data.ImageUrl,
                    Date = data.Date,
                    Genres = data.Genres,
                    Duration = data.Duration,
                    Director = data.Director,
                };

                if (data.Characters != null)
                {
                    movie.Characters = data.Characters.Select(c => new CharacterDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        IdEntertainment = c.IdEntertainment
                    }).ToList();
                };

                return movie;
            }

            return null;
        }
    }
}
