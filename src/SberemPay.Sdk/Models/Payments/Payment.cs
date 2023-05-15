using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SberemPay.Sdk.Models.Payments
{
    public class Payment
    {
        public string Id { get; set; }
        public string ReferenceId { get; set; }
        public string ParentPaymentId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CheckoutUrl { get; set; }
        public long TotalAmount { get; set; }
        public long DiscountAmount { get; set; }
        public long FinalAmount { get; set; }
        public long PaidAmount { get; set; }
        public long PaidVoucherAmount { get; set; }
        public long Amount { get; set; }
        public bool IsSingleTransaction { get; set; }
        public PaymentStaus Status { get; set; }
        public PaymentMode Mode { get; set; }
        public bool HasWallet { get; set; }

        public List<PaymentLine> PaymentLines { get; set; }
        public List<PaymentDiscount> PaymentDiscounts { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}
