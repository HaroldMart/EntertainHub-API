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
        public int Episodes { get; set; }
        public string Director { get; set; }
    }
}
