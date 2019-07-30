using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mic.EFC.Repository.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            Genders = new GenderRepository(_dbContext);
            Students = new StudentRepository(_dbContext);
            Teachers = new TeacherRepository(_dbContext);
            Universities = new UniversityRepository(_dbContext);
        }

        public IGenderRepository Genders { get; private set; }
        public IStudentRepository Students { get; private set; }
        public ITeacherRepository Teachers { get; private set; }
        public IUniversityRepository Universities { get; private set; }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
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
    }
}
