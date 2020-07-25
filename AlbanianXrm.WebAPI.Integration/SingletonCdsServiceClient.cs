using Microsoft.PowerPlatform.Cds.Client;
using System;

namespace AlbanianXrm.WebAPI.Integration
{
    public partial class Startup
    {
        private class SingletonCdsServiceClient
        {
            public readonly CdsServiceClient cdsServiceClient;

            public SingletonCdsServiceClient(CdsClientConfig cdsClientConfig)
            {
                cdsServiceClient = new CdsServiceClient(cdsClientConfig.Uri, cdsClientConfig.ClientId, cdsClientConfig.ClientSecret, cdsClientConfig.UseUniqueInstance, cdsClientConfig.TokenCache);
                if (cdsClientConfig.CallerId.HasValue)
                {
                    cdsServiceClient.CallerId = cdsClientConfig.CallerId.Value;
                }               
            }
        }
    }
   
}
