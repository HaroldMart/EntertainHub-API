using Data.Models.Content;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;

namespace Repository.Services
{
    public class NovelService : Repo<Novel>
    {
        public NovelService(LibraryContext dbcontext) : base(dbcontext) { }

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
            ReadingContentDto novel;

            if (data != null)
            {
                novel = new ReadingContentDto
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
                    novel.Characters = data.Characters.Select(c => new CharacterDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        IdEntertainment = c.IdEntertainment
                    }).ToList();
                };

                return novel ;
            }

            return null;
        }
    }
}
