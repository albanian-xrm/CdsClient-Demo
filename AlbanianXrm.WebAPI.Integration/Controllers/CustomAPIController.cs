using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using System.Threading.Tasks;

namespace AlbanianXrm.WebAPI.Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomAPIController : ControllerBase
    {
        private readonly ServiceClient organizationService;

        public CustomAPIController(ServiceClient organizationService)
        {
            this.organizationService = organizationService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<string> Get()
        {
            return (await organizationService.ExecuteAsync(new OrganizationRequest("albxrm_Function"))).Results["Message"] as string;
        }

        [HttpPost]
        public async Task<string> Post()
        {
            return (await organizationService.ExecuteAsync(new OrganizationRequest("albxrm_Action"))).Results["Message"] as string;
        }
    }
}
