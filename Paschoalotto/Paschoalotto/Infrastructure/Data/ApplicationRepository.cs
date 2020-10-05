using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Paschoalotto.Infrastructure.Data
{
    public class ApplicationRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
    {
        private readonly ApplicationDataContext _repositoryContext;
        private readonly DbSet<T> _dbSet;

        public ApplicationRepository(ApplicationDataContext repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
            _dbSet = _repositoryContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Any(expression);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            T existing = _dbSet.Find(entity);
            if (existing != null) _dbSet.Remove(existing);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _dbSet.AddAsync(entity, new CancellationToken());

            return result.Entity;
        }

        public IQueryable<T> FindByConditionAttached(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
