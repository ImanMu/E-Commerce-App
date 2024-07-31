using ECommerce.Context;
using ECommerce.Models;
using ECommerce.Repositories.Contract;
using ECommerce.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories.Repository
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		DBContext context;
		public OrderRepository(DBContext _context) : base(_context)
		{
			context = _context;
		}
	}
}

