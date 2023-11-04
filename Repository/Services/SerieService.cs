using Data.Models.Content;
using Data;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Interfaces;

namespace Repository.Services
{
    public class SerieService : Repo<Serie>, IService<SerieDto>
    {
        public SerieService(LibraryContext dbcontext) : base(dbcontext) { }

        public ICollection<SerieDto> GetAll()
        {
            var data = EntrySet.AsNoTracking().Select(p => new SerieDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageFile = p.ImageFile,
                Release = p.Release,
                ImageUrl = p.ImageUrl,
                Date = p.Date,
                Seasons = p.Seasons,
                Episodes = p.Episodes,
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
        public SerieDto? Get(int id)
        {
            var data = EntrySet.Include(c => c.Characters).FirstOrDefault(i => i.Id == id);
            SerieDto serie;

            if (data != null)
            {
                serie = new SerieDto
                {
                    Id = data?.Id,
                    Name = data.Name,
                    Description = data.Description,
                    ImageFile = data.ImageFile,
                    Release = data.Release,
                    ImageUrl = data.ImageUrl,
                    Date = data.Date,
                    Seasons = data.Seasons,
                    Episodes = data.Episodes,
                    Director = data.Director,
                };

                if (data.Characters != null)
                {
                    serie.Characters = data.Characters.Select(c => new CharacterDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        IdEntertainment = c.IdEntertainment
                    }).ToList();
                };

                return serie;
            }

            return null;
        }
    }
}
