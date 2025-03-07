using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Form_API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        protected DbSet<T> _dbSet;

        public GenericRepository(DbContext dbContext) // instantiate this class with a DBContext 
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>(); //access db tables and return values
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            //_dbContext.Entry(entity).State = EntityState.Modified; //
            _dbContext.SaveChanges(); // save recent db updates
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges(); // presist recent changes
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity); // add entity to db set
            _dbContext.Entry(entity).State = EntityState.Modified; // 
            _dbContext.SaveChanges(); // presist recent changes
        }
    }
}
