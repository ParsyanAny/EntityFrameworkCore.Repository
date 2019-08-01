using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mic.EFC.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        protected readonly DbContext _context;
        protected BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public void Create(TEntity entity) => _context.Set<TEntity>().Add(entity);
        public Task CreateAsync(TEntity entity)
            => _context.Set<TEntity>().AddAsync(entity);
        public void CreateMany(IEnumerable<TEntity> entities)
            => _context.Set<TEntity>().AddRange(entities);
        public Task CreateManyAsync(IEnumerable<TEntity> entities)
            => _context.Set<TEntity>().AddRangeAsync(entities);
        public void DeleteById(int id)
        {
            var entityToRemove = GetById(id);
            Delete(entityToRemove);
        }
        public async void DeleteByIdAsync(int id)
        {
            var entityToRemove = await GetByIdAsync(id);
            Delete(entityToRemove);
        }
        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);
        public void DeleteRange(IEnumerable<TEntity> entities)
            => _context.Set<TEntity>().RemoveRange(entities);

        public bool Any(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().Any(predicate);
        public TEntity GetById(int id) => _context.Set<TEntity>().Find(id);
        public Task<TEntity> GetByIdAsync(int id)
            => _context.Set<TEntity>().FindAsync(id);
        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>();
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().Where(predicate);
        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);
        public void UpdateRange(IEnumerable<TEntity> entities)
            => _context.Set<TEntity>().UpdateRange(entities);
        public void SaveChanges() => _context.SaveChanges();
        public Task SaveChangesAsync()
            => _context.SaveChangesAsync();
    }
}
