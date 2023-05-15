using SberemPay.Sdk.Models.Payments;

namespace SberemPay.Sdk.Requests
{
    public class UpdatePaymentGatewaysRequest
    {
        public List<UpdatePaymentGatewayRequest> Items { get; set; }
    }
}
