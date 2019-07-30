using Mic.EFC.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Mic.EFC.Repository.Impl
{
    public class TeacherRepository : BaseRepository<Teachers>
    {
        public TeacherRepository(DbContext context) : base(context) { }
    }
}
