using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositories.Contract
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        void Create(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
