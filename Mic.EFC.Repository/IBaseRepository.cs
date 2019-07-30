
namespace Mic.EFC.Repository
{
    interface IBaseRepository<TEntity> : IActionRepository<TEntity>, IReadOnlyRepository<TEntity>
         where TEntity : class, new()
    { }
}
