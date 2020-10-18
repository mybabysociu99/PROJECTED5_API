using System;
using System.Collections.Generic;

namespace PROJECTED5.Models
{
    public partial class Receipt
    {
        public string ReceiptId { get; set; }
        public string ReceiptName { get; set; }
        public string StudentsId { get; set; }
        public string SubjectsId { get; set; }
        public string FacultyId { get; set; }
        public double? PaymentAmount { get; set; }
        public string PaymentReason { get; set; }
        public string Payer { get; set; }
        public string MoneyReceiver { get; set; }
        public string CreatorName { get; set; }

        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
