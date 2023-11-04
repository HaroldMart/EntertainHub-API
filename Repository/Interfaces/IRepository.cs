using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T>
    {
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
