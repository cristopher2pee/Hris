using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Config
{
    public class AzureAdConfig
    {
        public static string Name { get;} = "AzureAd";

        public string Instance { get; set; }
        public string ClientId { get; set; }
        public string TenantId { get; set; }
        public string Scopes { get; set; }

    }
}
