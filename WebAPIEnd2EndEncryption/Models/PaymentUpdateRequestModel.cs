using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIEnd2EndEncryption.Models
{
    public class PaymentUpdateRequestModel
    {
        public string customerName { get; set; }
        public string phoneNumber { get; set; }
        public int referenceID { get; set; }
        public string transReference { get; set; }
        public string hash { get; set; }
    }
}