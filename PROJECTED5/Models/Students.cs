using System;
using System.Collections.Generic;

namespace PROJECTED5.Models
{
    public partial class Students
    {
        public Students()
        {
            Receipt = new HashSet<Receipt>();
        }

        public string StudentsId { get; set; }
        public string StudentsName { get; set; }
        public string FacultyId { get; set; }
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string StudentsAddress { get; set; }
        public double? FristPoint { get; set; }
        public bool? StatusPay { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
