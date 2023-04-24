using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SberemPay.Sdk.Models.Payments
{
    public class PaymentDiscount
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public string DiscountName { get; set; }
        public string DiscountDescription { get; set; }
        public long Amount { get; set; }
        public int? Type { get; set; }
        public long? Value { get; set; }
        public int? Index { get; set; }
    }
}
