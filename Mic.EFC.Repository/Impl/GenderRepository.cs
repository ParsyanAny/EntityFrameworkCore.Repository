using Mic.EFC.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Mic.EFC.Repository.Impl
{
    public class GenderRepository : BaseRepository<Genders>
    {
        public GenderRepository(DbContext context) : base(context) { }
    }
}
