using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIEnd2EndEncryption.Models
{
    public class Payment
    {
        public int ReferenceID { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string PhoneNumber { get; set; }
        public string Currency { get; set; }
        public string TransReference { get; set; }
    }
}