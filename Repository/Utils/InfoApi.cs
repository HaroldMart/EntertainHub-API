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
using Microsoft.EntityFrameworkCore;

namespace Repository.Utils
{
    public class InfoApi : IGetInfo
    {
        private readonly DbContext _dbContext;
        public InfoApi(DbContext dbContext) {

            _dbContext = dbContext;
        }
        public object GenerateJson(object countData, object endPoints, object methods, object schemas)
        {
            var data = new 
            {
                Count = countData,
                Endpoints = endPoints,
                Methods = methods,
                Schemas = schemas
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            return json;
        }

        public object CountData()
        {
            var count = new
            {
                Animes = _dbContext.Set<Anime>().ToList().Count,
                Books = _dbContext.Set<Book>().ToList().Count,
                Series = _dbContext.Set<Serie>().ToList().Count,
                Movies = _dbContext.Set<Movie>().ToList().Count,
                Comics = _dbContext.Set<Comic>().ToList().Count,
                Mangas = _dbContext.Set<Manga>().ToList().Count,
                Novels = _dbContext.Set<Novel>().ToList().Count,
                Characters = _dbContext.Set<Character>().ToList().Count,
            };
           
            return count;
        }

        public object ListEndpoints()
        {
            var urls = new
            {
                Animes = "entertainHubApi/Anime",
                Book = "entertainHubApi/Book",
                Series = "entertainHubApi/Serie",
                Movies = "entertainHubApi/Movie",
                Comics = "entertainHubApi/Comic",
                Mangas = "entertainHubApi/Manga",
                Novels = "entertainHubApi/Novel",
                Characters = "entertainHubApi/Character",
            };

            return urls;
        }

        public object ListMethods()
        {
            var methods = new
            {
                GetAll = "entertainHubApi/model",
                Get = "entertainHubApi/model/Get/3",
                Insert = "entertainHubApi/model/Insert",
                Update = "entertainHubApi/model/Update",
                Delete = "entertainHubApi/model/Delete/1"
            };

            return methods;
        }

        public object ListSchemas()
        {
            var schemas = new
            {
                Animes = new
                {
                    name = "string",
                    description = "string",
                    release = "string",
                    date = "string",
                    imageUrl = "string",
                    genres = "string",
                    seasons = "int",
                    studio = "string",
                    episodes = "int"
                },

                Books = new
                {
                    name = "string",
                    description = "string",
                    release = "string",
                    date = "string",
                    imageUrl = "string",
                    genres = "string",
                    pages = "int",
                    author = "string"
                },

                Mangas = new
                {
                    name = "string",
                    description = "string",
                    release = "string",
                    date = "string",
                    imageUrl = "string",
                    genres = "string",
                    pages = "int",
                    author = "string"
                },

                Novels = new
                {
                    name = "string",
                    description = "string",
                    release = "string",
                    date = "string",
                    imageUrl = "string",
                    genres = "string",
                    pages = "int",
                    author = "string"
                },

                Series = new
                {
                    name = "string",
                    description = "string",
                    release = "string",
                    date = "string",
                    imageUrl = "string",
                    genres = "string",
                    seasons = "int",
                    episodes = "int",
                    director = "string"
                },

                Movies = new
                {
                    name = "string",
                    description = "string",
                    release = "string",
                    date = "string",
                    imageUrl = "string",
                    genres = "string",
                    episodes = "int",
                    duration = "string",
                    director = "string"
                },

                Comics = new
                {
                    name = "string",
                    description = "string",
                    release = "string",
                    date = "string",
                    imageUrl = "string",
                    genres = "string",
                    pages = "int",
                    author = "string"
                },

                Characters = new
                {
                    name = "string",
                    description = "string",
                    IdEntertainment = "int",
                }
            };

            return schemas;
        }
    }
}
