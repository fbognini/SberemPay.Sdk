namespace SberemPay.Sdk.Models.PaymentGateways
{
    public class PaymentGateway
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public PaymentGateway FallbackPaymentGateway { get; set; }
    }
}
