using fbognini.Sdk;
using fbognini.Sdk.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SberemPay.Sdk.Endpoints;
using SberemPay.Sdk.Models.PaymentGateways;
using SberemPay.Sdk.Models.PaymentMethods;
using SberemPay.Sdk.Models.Payments;
using SberemPay.Sdk.Requests;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SberemPay.Sdk
{
    public interface ISberemPayApiService
    {
        #region Payments
        Task<ApiResult<Payment>> ConfirmPayment(string id);
        Task<ApiResult<Payment>> CreatePayment(CreatePaymentRequest request);
        Task<ApiResult<Payment>> GetPayment(string id);
        Task<ApiResult<PaginationResponse<Payment>, Payment>> GetPayments(int pageNumber, int pageSize);
        Task<ApiResult<Payment>> RefundPayment(string id);

        #endregion

        #region Customer

        Task<List<PaymentMethod>> GetCustomerPaymentMethods(string id);
        Task<ApiResult> DeletePaymentMethod(string id);

        #endregion

        #region Payment Gateways
        
        Task<PaymentGatewayResponse> GetMerchantPaymentGateways();

        Task<ApiResult> UpdateMerchantPaymentGateways(UpdatePaymentGatewaysRequest request);
        
        #endregion
    }

    internal class SberemPayApiService : BaseApiService, ISberemPayApiService
    {
        private InternalSberemPayApiSettings settings;

        public SberemPayApiService(HttpClient client, ILogger<SberemPayApiService> logger, IOptions<InternalSberemPayApiSettings> options)
            : base(client, logger, options: new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() },
            })
        {
            settings = options.Value;
            ChangeSettings(settings);
        }

        private void ChangeSettings(InternalSberemPayApiSettings settings)
        {
            if (settings is null)
                return;

            base.client.BaseAddress = new Uri(settings.GetUrl());

            client.DefaultRequestHeaders.Add("X-API-Key", settings.ApiKey);

            this.settings = settings;
        }

        public async Task<ApiResult<PaginationResponse<Payment>, Payment>> GetPayments(int pageNumber, int pageSize)
        {
            return await GetApi<ApiResult<PaginationResponse<Payment>, Payment>>(PaymentEndpoints.GetPayments(pageNumber, pageSize));
        }

        public async Task<ApiResult<Payment>> GetPayment(string id)
        {
            return await GetApiResult<Payment>(PaymentEndpoints.GetPayment(id));
        }

        public async Task<ApiResult<Payment>> CreatePayment(CreatePaymentRequest request)
        {
            return await PostApiResult<Payment, CreatePaymentRequest>(PaymentEndpoints.CreatePayment(), request);
        }

        public async Task<ApiResult<Payment>> ConfirmPayment(string id)
        {
            return await PostApiResult<Payment>(PaymentEndpoints.ConfirmPayment(id));
        }

        public async Task<ApiResult<Payment>> RefundPayment(string id)
        {
            return await PostApiResult<Payment>(PaymentEndpoints.RefundPayment(id));
        }

        public async Task<List<PaymentMethod>> GetCustomerPaymentMethods(string id)
        {
            return await GetApi<List<PaymentMethod>>(CustomerEndpoints.GetPaymentMethods(id));
        }

        public async Task<ApiResult> DeletePaymentMethod(string id)
        {
            return await DeleteApiResult(PaymentMethodEndpoints.DeletePaymentMethod(id));
        }

        public async Task<PaymentGatewayResponse> GetMerchantPaymentGateways()
        {
            return await GetApi<PaymentGatewayResponse>(MerchantEndpoints.GetMerchantPaymentGateways());
        }

        public async Task<ApiResult> UpdateMerchantPaymentGateways(UpdatePaymentGatewaysRequest request)
        {
            return await PostApiResult<UpdatePaymentGatewaysRequest>(MerchantEndpoints.UpdateMerchantPaymentGateways(), request);
        }
    }
}