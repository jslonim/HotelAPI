using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);

        void Save();
    }
}
