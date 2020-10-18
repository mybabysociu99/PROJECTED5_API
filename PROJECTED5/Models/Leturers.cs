using System;
using System.Collections.Generic;

namespace PROJECTED5.Models
{
    public partial class Leturers
    {
        public string LeturersId { get; set; }
        public string FacultyId { get; set; }
        public string LeturersName { get; set; }
        public string LeturersPhone { get; set; }
        public string LeturersAddress { get; set; }
        public string LeturersDegree { get; set; }
        public string LeturersSpecialized { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
