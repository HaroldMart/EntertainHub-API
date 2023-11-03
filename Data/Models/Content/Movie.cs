using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Content
{
    public class Movie : Entertainment
    {
        public string Duration { get; set; }
        public string Director { get; set; }
    }
}
