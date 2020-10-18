using System;
using System.Collections.Generic;

namespace PROJECTED5.Models
{
    public partial class Scores
    {
        public string ScoresId { get; set; }
        public string StudentsId { get; set; }
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string FacultyId { get; set; }
        public string LeturersId { get; set; }
        public double? FristPoint { get; set; }
        public double? SecondPoint { get; set; }
        public bool? Status { get; set; }
        public string Note { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
