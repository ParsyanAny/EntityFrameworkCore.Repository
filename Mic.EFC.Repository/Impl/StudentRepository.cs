using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mic.EFC.Repository.Impl
{
    public class StudentRepository : BaseRepository<Students>
    {
        public StudentRepository(DbContext context) : base(context) { }
    }
}
