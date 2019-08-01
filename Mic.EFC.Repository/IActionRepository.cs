using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mic.EFC.Repository
{
    public interface IActionRepository<TEntity>
        where TEntity : class, new()
    {
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateMany(IEnumerable<TEntity> entities);
        Task CreateManyAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteById(int id);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
