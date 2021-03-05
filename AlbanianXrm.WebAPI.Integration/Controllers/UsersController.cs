using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlbanianXrm.WebAPI.Integration.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ServiceClient organizationService;

        public UsersController(ServiceClient organizationService)
        {
            this.organizationService = organizationService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return (await organizationService.RetrieveMultipleAsync(new QueryExpression("systemuser") { ColumnSet = new ColumnSet("fullname") })).Entities.Select(u => u.GetAttributeValue<string>("fullname"));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<string> Get(Guid id)
        {
            return (await organizationService.RetrieveAsync("systemuser", id, new ColumnSet("fullname"))).GetAttributeValue<string>("fullname");
        }
    }
}
