using System.Collections.Generic;

namespace Mic.EFC.Repository.Models
{
    public partial class Genders
    {
        public Genders()
        {
            Students = new HashSet<Students>();
            Teachers = new HashSet<Teachers>();
        }

        public byte Id { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
