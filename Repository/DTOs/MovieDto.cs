﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
    public class MovieDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Release { get; set; }
        public string ImageUrl { get; set; }
        public string Date { get; set; }
        public string Genres { get; set; }
        public string Duration { get; set; }
        public string Director { get; set; }
        public ICollection<CharacterDto>? Characters { get; set; }
    }
}
