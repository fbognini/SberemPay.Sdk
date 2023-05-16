using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberemPay.Sdk.Endpoints
{
    internal static class MerchantEndpoints
    {
        private const string Endpoint = "merchant";

        public static string GetMerchantPaymentGateways() => $"v1/{Endpoint}/payment-gateways";
        public static string UpdateMerchantPaymentGateways() => $"v1/{Endpoint}/payment-gateways";
    }
}
