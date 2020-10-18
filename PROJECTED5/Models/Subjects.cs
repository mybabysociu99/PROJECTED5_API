using System;
using System.Collections.Generic;

namespace PROJECTED5.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            Receipt = new HashSet<Receipt>();
        }

        public string SubjectsId { get; set; }
        public string SubjectsName { get; set; }
        public string SubjectsCredit { get; set; }

        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
