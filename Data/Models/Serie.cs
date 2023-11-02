using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Release { get; set; }
        public string Date { get; set; }
        public int Seasons { get; set; }
        public string Episodes { get; set; }
        public int Director { get; set; }
    }
}
