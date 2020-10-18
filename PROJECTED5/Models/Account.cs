using System;
using System.Collections.Generic;

namespace PROJECTED5.Models
{
    public partial class Account
    {
        public string AccountId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool? Status { get; set; }
    }
}
