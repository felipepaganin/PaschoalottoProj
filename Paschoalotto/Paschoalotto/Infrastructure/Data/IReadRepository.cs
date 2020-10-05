using System;
using System.Linq;
using System.Linq.Expressions;

namespace Paschoalotto.Infrastructure.Data
{
    public interface IReadRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
    }
}
