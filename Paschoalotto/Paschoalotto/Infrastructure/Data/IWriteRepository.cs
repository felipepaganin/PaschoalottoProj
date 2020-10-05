using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Paschoalotto.Infrastructure.Data
{
    public interface IWriteRepository<T> where T : class
    {
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> FindByConditionAttached(Expression<Func<T, bool>> expression);
    }

}
