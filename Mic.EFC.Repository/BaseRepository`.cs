using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        public void Create(TEntity entity)
        {
            if (entity != null)
                _context.Set<TEntity>().Add(entity);
        }

        public void CreateMany(IEnumerable<TEntity> entities)
        {
            if (entities != null)
                _context.Set<TEntity>().AddRange(entities);
        }

        public void DeleteById(int id)
        {
            var entityToRemove = GetById(id);
            if (entityToRemove != null)
                _context.Set<TEntity>().Remove(entityToRemove);
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
                _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
                _context.Set<TEntity>().RemoveRange(entities);
        }

        public bool Any(TEntity entity)
        {
            if (entity != null)
                return _context.Set<TEntity>().Any(p => p == entity);
            else
                return false;
        }

        public TEntity GetById(int id) => _context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>();

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().Where(predicate);

        public void Update(TEntity entity)
        {
            if (entity != null)
                _context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities != null)
                _context.Set<TEntity>().UpdateRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
