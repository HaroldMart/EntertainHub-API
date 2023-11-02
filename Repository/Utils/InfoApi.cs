using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Utils
{
    public class InfoApi<T> : IGetInfo<T>
    {
        public async Task<object> CountData(T data)
        {
            throw new NotImplementedException();
        }

        public Task<object> ListEndpoints(T entity)
        {
            ICollection<string> endpoints = new List<string>()
            {

            };

            throw new NotImplementedException();
        }
    }
}
