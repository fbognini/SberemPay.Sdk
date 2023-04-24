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
        public string Override { get; set; }
        public string ApiKey { get; set; }
    }

    internal class InternalSberemPayApiSettings
    {
        private readonly Dictionary<SberemPayApiEnvironment, string> Urls = new()
        {
            [SberemPayApiEnvironment.STG] = "https://api-stg.sberempay.com/",
            [SberemPayApiEnvironment.PRD] = "https://api.sberempay.com/",
        };

        public SberemPayApiEnvironment? Environment { get; set; }
        public string Override { get; set; }
        public string ApiKey { get; set; }

        internal string GetUrl()
        {
            if (!string.IsNullOrWhiteSpace(Override))
            {
                return Override;
            }

            return Urls[Environment ?? SberemPayApiEnvironment.PRD];
        }
    }
}
