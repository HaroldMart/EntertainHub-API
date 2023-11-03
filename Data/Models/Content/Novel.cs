using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Content
{
    public class Novel : Entertainment
    {
        public int Pages { get; set; }
        public string Author { get; set; }
    }
}
