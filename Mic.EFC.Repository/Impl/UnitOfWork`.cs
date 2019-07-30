using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mic.EFC.Repository.Impl
{
    public class UnitOfWork_ : IDisposable, IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public UnitOfWork_(DbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        //public UnitOfWork_()
        //{
        //    _dbContext = new DbContext();
        //}

        public BaseRepository<TEntity> Repository<TEntity>()
        where TEntity : class, new()
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);
                repositories.Add(type, repositoryInstance);
            }
            return (BaseRepository<TEntity>)repositories[type];
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}

