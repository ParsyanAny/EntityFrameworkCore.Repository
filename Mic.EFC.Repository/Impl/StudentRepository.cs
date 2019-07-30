using Mic.EFC.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Mic.EFC.Repository.Impl
{
    public class StudentRepository : BaseRepository<Students>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context) { }
    }
}
