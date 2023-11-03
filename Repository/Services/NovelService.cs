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
    public class NovelService : Repo<Novel>
    {
        public NovelService(LibraryContext dbcontext) : base(dbcontext) { }

        public override Task<IEnumerable<Novel>> GetAll()
        {
            var data = (IEnumerable<Novel>)EntrySet.AsNoTracking().Select(p => new Novel
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

            return (Task<IEnumerable<Novel>>)data;
        }
        public override async Task<Novel> Get(int id)
        {
            var data = (Novel)EntrySet.AsNoTracking().Select(p => new Novel
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
