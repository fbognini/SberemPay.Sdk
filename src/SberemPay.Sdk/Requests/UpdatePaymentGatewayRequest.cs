using SberemPay.Sdk.Models.Payments;

namespace SberemPay.Sdk.Requests
{
    public class UpdatePaymentGatewayRequest
    {
        public string Id { get; set; }
        public UpdatePaymentGatewayRequest FallbackPaymentGateway { get; set; }
    }
}
