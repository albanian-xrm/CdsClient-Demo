using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbanianXrm.WebAPI.Integration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlbanianXrm.WebAPI.Integration.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ServiceClient organizationService;

        public AccountsController(ServiceClient organizationService)
        {
            this.organizationService = organizationService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {
            return (await organizationService.RetrieveMultipleAsync(new QueryExpression("account") { ColumnSet = new ColumnSet("name", "ownerid") })).Entities.Select(u => new
            {
                u.Id,
                Name = u.GetAttributeValue<string>("name"),
                Owner = u.GetAttributeValue<EntityReference>("ownerid")?.Name
            });
        }

        [HttpPost]
        public async Task<Guid> Post(AccountBindingModel account)
        {
            var create = new Entity("account");
            create["name"] = account.Name ?? "Name";
            return await organizationService.CreateAsync(create);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<string> Get(Guid id)
        {
            return (await organizationService.RetrieveAsync("account", id, new ColumnSet("name"))).GetAttributeValue<string>("name");
        }
    }
}
