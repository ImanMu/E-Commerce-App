using ECommerce.Context;
using ECommerce.Models;
using ECommerce.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories.Repository
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
	{
        DBContext context;
        public ProductRepository(DBContext _context) : base(_context)
        {
            context = _context;
        }
		//public IQueryable<Product> Search(string s)
		//{
		//    return context.Products.Where(p => p.ProductName.Contains(s));
		//}
	}
}
