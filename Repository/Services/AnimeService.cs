using Data;
using Data.Models;
using Data.Models.Content;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class AnimeService : Repo<Anime>
    {
        public AnimeService(LibraryContext dbcontext) : base(dbcontext) { }

        public ICollection<AnimeDto> GetAll()
        {
            var data = EntrySet.AsNoTracking().Select(p => new AnimeDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                Release = p.Release,
                Date = p.Date,
                Seasons = p.Seasons,
                Studio = p.Studio,
                Episodes = p.Episodes,
                Characters =
           p.Characters
            .Select(c => new CharacterDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList()
            }).ToList();

            return data;
        }
        public AnimeDto? Get(int id)
        {
            var data = EntrySet.Include(c => c.Characters).FirstOrDefault(i => i.Id == id);
            AnimeDto animes;

            if(data != null)
            {
                animes = new AnimeDto
                {
                    Id = data?.Id,
                    Name = data.Name,
                    Description = data.Description,
                    Image = data.Image,
                    Release = data.Release,
                    Date = data.Date,
                    Seasons = data.Seasons,
                    Studio = data.Studio,
                    Episodes = data.Episodes,
                };

                if (data.Characters != null)
                {
                    animes.Characters = data.Characters.Select(c => new CharacterDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description
                    }).ToList();
                };

                return animes;
            }

            return null;
        }
    }
}
