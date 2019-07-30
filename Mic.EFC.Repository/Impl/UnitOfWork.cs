using Mic.EFC.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
            Teacher = new TeacherRepository(_dbContext);
            University = new UniversityRepository(_dbContext);
        }

        public IGenderRepository Genders { get; private set; }
        public IStudentRepository Students { get; private set; }
        public ITeacherRepository Teacher { get; private set; }
        public IUniversityRepository University { get; private set; }


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
            throw new System.NotImplementedException();
        }
    }
}
