using System;
using System.Collections.Generic;

namespace PROJECTED5.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Class = new HashSet<Class>();
            Leturers = new HashSet<Leturers>();
            Scores = new HashSet<Scores>();
        }

        public string FacultyId { get; set; }
        public string FacultyName { get; set; }

        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<Leturers> Leturers { get; set; }
        public virtual ICollection<Scores> Scores { get; set; }
    }
}
