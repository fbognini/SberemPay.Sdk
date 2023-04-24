using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SberemPay.Sdk.Models.PaymentMethods
{
    public class PaymentMethod
    {
        public string Id { get; set; }
        public string PaymentGatewayId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pan { get; set; }
        public string PanExpiration { get; set; }
    }
}
