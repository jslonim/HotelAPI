using HotelAPI.Data.Context;
using HotelAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelAPI.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context = null;
        private DbSet<T> table = null;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            table = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.AsNoTracking().ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).AsNoTracking();
        }
        public async void Insert(T obj)
        {
            await table.AddAsync(obj);
        }
        public void Update(T obj)
        {
            table.Update(obj);
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
