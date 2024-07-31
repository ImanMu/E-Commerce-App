using ECommerce.Models;
using ECommerce.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Repositories.Contract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        //IQueryable<Product> Search(string s);
    }
}
