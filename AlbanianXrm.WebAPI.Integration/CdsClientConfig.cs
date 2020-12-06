using System;

namespace AlbanianXrm.WebAPI.Integration
{
    public class CdsClientConfig
    {
        public Uri Uri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public Guid? CallerId { get; set; }
        public bool UseUniqueInstance { get; set; }
    }
}
