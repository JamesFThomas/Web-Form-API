using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Form_API.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        // basic structure of any respository we add to this application in the future
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}
