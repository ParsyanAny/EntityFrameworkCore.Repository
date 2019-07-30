using System;
using System.Collections.Generic;
using System.Text;

namespace Mic.EFC.Repository.Models
{
    public partial class Universities
    {
        public Universities()
        {
            Students = new HashSet<Students>();
            TeacherUniversity = new HashSet<TeacherUniversity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DestroyDate { get; set; }

        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<TeacherUniversity> TeacherUniversity { get; set; }
    }
}
