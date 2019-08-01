using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mic.EFC.Repository
{
    public interface IReadOnlyRepository<TEntity>
         where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
    }
}

