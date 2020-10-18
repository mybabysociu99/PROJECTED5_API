using System;
using System.Collections.Generic;

namespace PROJECTED5.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Students>();
        }

        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string StudentsId { get; set; }
        public string FacultyId { get; set; }
        public string SubjectsId { get; set; }
        public string LeturersId { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? FinishDay { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
