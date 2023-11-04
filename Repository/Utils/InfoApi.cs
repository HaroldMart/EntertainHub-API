using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Data;
using Data.Models;
using System.Security.Policy;
using Data.Models.Content;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Repository.Utils
{
    public class InfoApi : IGetInfo
    {
        private readonly LibraryContext _dbContext;
        public InfoApi(LibraryContext dbContext) {

            _dbContext = dbContext;
        }
        public object GenerateJson(object countData, object endPoints, object methods)
        {
            var data = new
            {
                Count = countData,
                Endpoints = endPoints,
                Methods = methods
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            return json;
        }

        public object CountData()
        {
            int animesCount = _dbContext.Set<Anime>().ToList().Count;
            int booksCount = _dbContext.Set<Book>().ToList().Count;
            int seriesCount = _dbContext.Set<Serie>().ToList().Count;
            int moviesCount = _dbContext.Set<Movie>().ToList().Count;
            int comicsCount = _dbContext.Set<Comic>().ToList().Count;
            int mangasCount = _dbContext.Set<Manga>().ToList().Count;
            int novelsCount = _dbContext.Set<Novel>().ToList().Count;
            int characterCount = _dbContext.Set<Character>().ToList().Count;

            var count = new
            {
                Animes = $"{animesCount}",
                Books = $"{booksCount}",
                Series = $"{seriesCount}",
                Movies = $"{moviesCount}",
                Comics = $"{comicsCount}",
                Mangas = $"{mangasCount}",
                Novels = $"{novelsCount}",
                Characters = $"{characterCount}",
            };

            return count;
        }

        public object ListEndpoints()
        {
            var urls = new
            {
                Animes = "https://localhost:7115/entertainHubApi/Anime",
                Book = "https://localhost:7115/entertainHubApi/Book",
                Series = "https://localhost:7115/entertainHubApi/Serie",
                Movies = "https://localhost:7115/entertainHubApi/Movie",
                Comics = "https://localhost:7115/entertainHubApi/Comic",
                Mangas = "https://localhost:7115/entertainHubApi/Manga",
                Novels = "https://localhost:7115/entertainHubApi/Novel",
                Characters = "https://localhost:7115/entertainHubApi/Character",
            };

            return urls;
        }

        public object ListMethods()
        {
            var methods = new
            {
                GetAll = "https://localhost:7115/entertainHubApi/model",
                Get = "https://localhost:7115/entertainHubApi/model/Get?id=3",
                Insert = "https://localhost:7115/entertainHubApi/model/Insert",
                Update = "https://localhost:7115/entertainHubApi/model/Update",
                Delete = "https://localhost:7115/entertainHubApi/model/Delete?id=1"
            };

            return methods;
        }
    }
}
