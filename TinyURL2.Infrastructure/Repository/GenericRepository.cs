using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL2.Business.Interfaces;
using TinyURL2.Infrastructure.DbContexts;

namespace TinyURL2.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly UrlDbContext _context;
        public GenericRepository(UrlDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public bool Delete(Guid id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                return false;
            }
            _context.Set<T>().Remove(entity);
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T? GetById(Guid id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                return default;
            }
            else return entity;
        }

        public IEnumerable<T> GetPaging(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public bool Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return true;
        }

        /// <summary>
        /// Search by fields query. 
        /// </summary>
        /// <param name="fields"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<T> RawQuery(string query)
        {
            DbSet<T> dbSet = _context.Set<T>();
            return dbSet.FromSqlRaw(query).AsEnumerable();
        }
    }
}
