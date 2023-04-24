using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberemPay.Sdk.Endpoints
{
    internal static class PaymentMethodEndpoints
    {
        private const string Endpoint = "payment_methods";

        public static string DeletePaymentMethod(string id) => $"v1/{Endpoint}/{id}";
    }
}
