using Data.Models.Content;
using Data;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Interfaces;

namespace Repository.Services
{
    public class ComicService : Repo<Comic>, IService<ReadingContentDto>
    {
        public ComicService(LibraryContext dbcontext) : base(dbcontext) { }

        public ICollection<ReadingContentDto> GetAll()
        {
            var data = EntrySet.AsNoTracking().Select(p => new ReadingContentDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Release = p.Release,
                ImageUrl = p.ImageUrl,
                Date = p.Date,
                Genres = p.Genres,
                Pages = p.Pages,
                Author = p.Author,
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
        public ReadingContentDto? Get(int id)
        {
            var data = EntrySet.Include(c => c.Characters).FirstOrDefault(i => i.Id == id);
            ReadingContentDto comic;

            if (data != null)
            {
                comic = new ReadingContentDto
                {
                    Id = data?.Id,
                    Name = data.Name,
                    Description = data.Description,
                    Release = data.Release,
                    ImageUrl = data.ImageUrl,
                    Date = data.Date,
                    Genres = data.Genres,
                    Pages = data.Pages,
                    Author = data.Author,
                };

                if (data.Characters != null)
                {
                    comic.Characters = data.Characters.Select(c => new CharacterDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        IdEntertainment = c.IdEntertainment
                    }).ToList();
                };

                return comic;
            }

            return null;
        }
    }
}
