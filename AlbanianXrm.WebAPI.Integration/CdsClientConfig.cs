using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbanianXrm.WebAPI.Integration
{
    public class CdsClientConfig
    {
        public Uri Uri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenCache { get; set; }
        public bool UseUniqueInstance { get; set; }
    }
}
