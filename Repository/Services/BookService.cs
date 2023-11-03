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
    public class BookService : Repo<Book>
    {
        public BookService(LibraryContext dbcontext) : base(dbcontext) { }

        public override Task<IEnumerable<Book>> GetAll()
        {
            var data = (IEnumerable<Book>)EntrySet.AsNoTracking().Select(p => new Book
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

            return (Task<IEnumerable<Book>>)data;
        }
        public override async Task<Book> Get(int id)
        {
            var data = (Book)EntrySet.AsNoTracking().Select(p => new Book
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
