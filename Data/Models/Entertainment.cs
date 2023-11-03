using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public abstract class Entertainment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]  Image { get; set; }
        public string Release { get; set; }
        public string Date { get; set; }
        public ICollection<Character>? Characters { get; set; }
    }
}
