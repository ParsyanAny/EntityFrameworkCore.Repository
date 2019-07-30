using System;
using System.Collections.Generic;
using System.Text;

namespace Mic.EFC.Repository.Models
{
    public partial class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UniversityId { get; set; }
        public byte GenderId { get; set; }

        public virtual Genders Gender { get; set; }
        public virtual Universities University { get; set; }
    }
}
