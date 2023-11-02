using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IGetInfo<T>
    {
        public Task<Object> CountData(T entity);
        public Task<Object> ListEndpoints(T entity);
    }
}
