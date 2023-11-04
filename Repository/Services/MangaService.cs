using Data.Models.Content;
using Data;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Interfaces;

namespace Repository.Services
{
    public class MangaService : Repo<Manga>, IService<ReadingContentDto>
    {
        public MangaService(LibraryContext dbcontext) : base(dbcontext) { }

        public ICollection<ReadingContentDto> GetAll()
        {
            var data = EntrySet.AsNoTracking().Select(p => new ReadingContentDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageFile = p.ImageFile,
                Release = p.Release,
                ImageUrl = p.ImageUrl,
                Date = p.Date,
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
            ReadingContentDto manga;

            if (data != null)
            {
                manga = new ReadingContentDto
                {
                    Id = data?.Id,
                    Name = data.Name,
                    Description = data.Description,
                    ImageFile = data.ImageFile,
                    Release = data.Release,
                    ImageUrl = data.ImageUrl,
                    Date = data.Date,
                    Pages = data.Pages,
                    Author = data.Author,
                };

                if (data.Characters != null)
                {
                    manga.Characters = data.Characters.Select(c => new CharacterDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        IdEntertainment = c.IdEntertainment
                    }).ToList();
                };

                return manga;
            }

            return null;
        }
    }
}
