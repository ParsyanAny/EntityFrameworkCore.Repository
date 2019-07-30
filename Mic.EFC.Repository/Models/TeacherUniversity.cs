using System;
using System.Collections.Generic;
using System.Text;

namespace Mic.EFC.Repository.Models
{
    public partial class TeacherUniversity
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int UniversityId { get; set; }

        public virtual Teachers Teacher { get; set; }
        public virtual Universities University { get; set; }
    }
}
