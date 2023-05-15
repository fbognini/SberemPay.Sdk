using SberemPay.Sdk.Models.Payments;
using System.Text.Json.Serialization;

namespace SberemPay.Sdk.Requests
{
    public class CreatePaymentRequest
    {
        public class PaymentLine
        {
            public int Quantity { get; set; }
            public int? PriceId { get; set; }
            public long UnitAmount { get; set; }
            public long UnitDiscountAmount { get; set; }
            public long DiscountAmount { get; set; }
            public int? ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public string ProductDescription { get; set; } = string.Empty;
            public string ProductImage { get; set; } = string.Empty;
            public bool IsFood { get; set; }
        }

        public class PaymentDiscount
        {
            public string DiscountName { get; set; } = string.Empty;
            public string DiscountDescription { get; set; } = string.Empty;
            public long? Amount { get; set; }
            public DiscountType? Type { get; set; }
            public long? Value { get; set; }
            /// <summary>
            /// if not null, the discount is applied to the amount discounted through the previous discounts
            /// </summary>
            public int? Index { get; set; }
        }

        public string ReferenceId { get; set; }
        public int? Timeout { get; set; }
        public string CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public bool IsSingleTransaction { get; set; }
        public string SelectedPaymentMethod { get; set; }
        public List<string> PaymentMethods { get; set; } = new();
        public string RedirectSuccessUrl { get; set; }
        public string RedirectErrorUrl { get; set; }
        public string S2SUrl { get; set; }
        public PaymentMode Mode { get; set; }
        public bool? HasWallet { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public List<PaymentLine> PaymentLines { get; set; } = new();
        public List<PaymentDiscount> PaymentDiscounts { get; set; } = new();
    }
}