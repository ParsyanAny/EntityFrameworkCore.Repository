using Mic.EFC.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Mic.EFC.Repository.Impl
{
    public class UniversityRepository : BaseRepository<Universities>
    {
        public UniversityRepository(DbContext context) : base(context) { }
    }
}
