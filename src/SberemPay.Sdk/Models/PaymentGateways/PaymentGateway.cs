namespace SberemPay.Sdk.Models.PaymentGateways
{
    public class PaymentGateway
    {
        public string PaymentGatewayId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public PaymentGateway FallbackPaymentGateway { get; set; }
    }
}
