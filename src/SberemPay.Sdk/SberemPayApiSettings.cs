using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberemPay.Sdk
{
    public enum SberemPayApiEnvironment
    {
        STG, PRD
    }


    public class SberemPayApiSettings
    {
        public SberemPayApiEnvironment Environment { get; set; }
        public string ApiKey { get; set; }
    }

    internal class InternalSberemPayApiSettings
    {
        private readonly Dictionary<SberemPayApiEnvironment, string> Urls = new()
        {
            [SberemPayApiEnvironment.STG] = "https://api-stg.voucherly.it/",
            [SberemPayApiEnvironment.PRD] = "https://api.voucherly.it/",
        };

        public SberemPayApiEnvironment? Environment { get; set; }
        public string ApiKey { get; set; }

        internal string GetUrl() => Urls[Environment ?? SberemPayApiEnvironment.PRD];
    }
}
