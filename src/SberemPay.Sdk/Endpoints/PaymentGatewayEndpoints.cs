using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberemPay.Sdk.Endpoints
{
    internal static class PaymentGatewayEndpoints
    {
        private const string Endpoint = "payment-gateways";

        public static string GetPaymentGateways() => $"v1/{Endpoint}";
        public static string UpdatePaymentGateways() => $"v1/{Endpoint}";
    }
}
