using ECommerce.Context;
using ECommerce.Models;
using ECommerce.Repositories.Contract;
using ECommerce.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories.Repository
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		DBContext context;
		public CategoryRepository(DBContext _context) : base(_context)
		{
			context = _context;
		}
	}
}