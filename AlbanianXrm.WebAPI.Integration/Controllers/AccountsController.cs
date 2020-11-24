using System;
using System.Collections.Generic;
using System.Linq;
using AlbanianXrm.WebAPI.Integration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlbanianXrm.WebAPI.Integration.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IOrganizationService organizationService;

        public AccountsController(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<object> Get()
        {      
            return organizationService.RetrieveMultiple(new QueryExpression("account") { ColumnSet = new ColumnSet("name", "ownerid") }).Entities.Select(u => new
            {
                Id = u.Id,
                Name = u.GetAttributeValue<string>("name"),
                Owner = u.GetAttributeValue<EntityReference>("ownerid")?.Name
            });
        }

        [HttpPost]
        public Guid Post(AccountBindingModel account)
        {
            var create = new Entity("account");
            create["name"] = account.Name ?? "Name";
            return organizationService.Create(create);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return organizationService.Retrieve("account", id, new ColumnSet("name")).GetAttributeValue<string>("name");
        }

    }
}
