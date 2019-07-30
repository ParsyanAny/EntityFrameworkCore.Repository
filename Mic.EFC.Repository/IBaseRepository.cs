
namespace Mic.EFC.Repository
{
    public interface IBaseRepository<TEntity> : IActionRepository<TEntity>, IReadOnlyRepository<TEntity>
         where TEntity : class, new()
    { }
}
