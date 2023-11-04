using Data;
using Data.Models;
using Data.Models.Content;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Repository.DTOs;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class AnimeService : Repo<Anime>, IService<AnimeDto>
    {
        public AnimeService(LibraryContext dbcontext) : base(dbcontext) { }

        public ICollection<AnimeDto> GetAll()
        {
            var data = EntrySet.AsNoTracking().Select(p => new AnimeDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Release = p.Release,
                ImageUrl = p.ImageUrl,
                Date = p.Date,
                Genres = p.Genres,
                Seasons = p.Seasons,
                Studio = p.Studio,
                Episodes = p.Episodes,
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
        public AnimeDto? Get(int id)
        {
            var data = EntrySet.Include(c => c.Characters).FirstOrDefault(i => i.Id == id);
            AnimeDto anime;

            if(data != null)
            {
                anime = new AnimeDto
                {
                    Id = data?.Id,
                    Name = data.Name,
                    Description = data.Description,
                    Release = data.Release,
                    ImageUrl = data.ImageUrl,
                    Date = data.Date,
                    Genres = data.Genres,
                    Seasons = data.Seasons,
                    Studio = data.Studio,
                    Episodes = data.Episodes,
                };

                if (data.Characters != null)
                {
                    anime.Characters = data.Characters.Select(c => new CharacterDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        IdEntertainment = c.IdEntertainment
                    }).ToList();
                };

                return anime;
            }

            return null;
        }
    }
}
