using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Repository.Utils
{
    public class InfoApi : IGetInfo
    {
        public async Task<object> CountData(InfoApi data)
        {
            throw new NotImplementedException();
        }

        public Task<object> ListEndpoints(InfoApi entity)
        {
            ICollection<string> endpoints = new List<string>()
            {

            };

            throw new NotImplementedException();
        }
    }
}
