using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Content
{
    public class Serie : Entertainment
    {
        public int Seasons { get; set; }
        public string Episodes { get; set; }
        public int Director { get; set; }
    }
}
