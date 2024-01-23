using fbognini.Sdk.Extensions;
using fbognini.Sdk.Handlers;
using fbognini.Sdk.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SberemPay.Sdk
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSberemPayApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<InternalSberemPayApiSettings>(configuration.GetSection(nameof(SberemPayApiSettings)));

            services.AddHttpClient<ISberemPayApiService, SberemPayApiService>()
                .ThrowApiExceptionIfNotSuccess()
                .AddLogging();

            return services;
        }
    }
}
