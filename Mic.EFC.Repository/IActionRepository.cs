using System.Collections.Generic;

namespace Mic.EFC.Repository
{
    interface IActionRepository<TEntity>
        where TEntity : class, new()
    {
        void Create(TEntity entity);
        void CreateMany(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteById(int id);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
