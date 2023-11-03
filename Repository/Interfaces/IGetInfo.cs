using Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IGetInfo
    {
        public Task<Object> CountData(InfoApi entity);
        public Task<Object> ListEndpoints(InfoApi entity);
    }
}
