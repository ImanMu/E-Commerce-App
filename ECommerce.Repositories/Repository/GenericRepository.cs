using ECommerce.Context;
using Microsoft.EntityFrameworkCore;
using ECommerce.Repositories.Contract;

namespace ECommerce.Repositories.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
		DBContext context;
        DbSet<T> dbset;
        public GenericRepository(DBContext _context)
        {
            context = _context;
            dbset = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return dbset;   

        }
        public void Create(T Entity)
        {
            dbset.Add(Entity);
            context.SaveChanges();  
        }
        public void Update(T Entity)
        {
            dbset.Update(Entity);
            context.SaveChanges();
        }
        public void Delete(T Entity)
        {
            dbset.Remove(Entity);
            context.SaveChanges();
        }
    }
}
