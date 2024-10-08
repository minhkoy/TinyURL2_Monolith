using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL2.Business.Interfaces
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T? GetById(Guid id);
        IEnumerable<T> GetPaging(int pageIndex, int pageSize);
        IQueryable<T> AsQueryable();
        T Add(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
