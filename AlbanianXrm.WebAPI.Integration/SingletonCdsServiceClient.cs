using Microsoft.PowerPlatform.Dataverse.Client;

namespace AlbanianXrm.WebAPI.Integration
{
    public partial class Startup
    {
        private class SingletonCdsServiceClient
        {
            public readonly ServiceClient cdsServiceClient;

            public SingletonCdsServiceClient(CdsClientConfig cdsClientConfig)
            {
                cdsServiceClient = new ServiceClient(cdsClientConfig.Uri, cdsClientConfig.ClientId, cdsClientConfig.ClientSecret, cdsClientConfig.UseUniqueInstance);
                if (cdsClientConfig.CallerId.HasValue)
                {
                    cdsServiceClient.CallerId = cdsClientConfig.CallerId.Value;
                }               
            }
        }
    }
   
}
