using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIEnd2EndEncryption.Models
{
    public class PaymentRepository
    {
        public static IList<Payment> GetPayments()
        {
            return new List<Payment>()
            {
                new Payment{Currency="NGN",CustomerName="John Doe",PhoneNumber="+2347099XXXXX",ReferenceID=23457122,TransReference="3812773QS",TotalAmount=240000.45m },
                new Payment{Currency="NGN",CustomerName="David Doe",PhoneNumber="+2347092XXXXX",ReferenceID=23445122,TransReference="3819773WS",TotalAmount=39000.51m },
                new Payment{Currency="NGN",CustomerName="Masson Dele",PhoneNumber="+2347059XXXXX",ReferenceID=21157122,TransReference="38312773XT",TotalAmount=40000.04m },
            };
        }
    }
}