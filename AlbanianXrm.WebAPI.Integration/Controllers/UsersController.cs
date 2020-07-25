using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlbanianXrm.WebAPI.Integration.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IOrganizationService organizationService;

        public UsersController(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return organizationService.RetrieveMultiple(new QueryExpression("systemuser") { ColumnSet = new ColumnSet("fullname") }).Entities.Select(u => u.GetAttributeValue<string>("fullname"));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return organizationService.Retrieve("systemuser", id, new ColumnSet("fullname")).GetAttributeValue<string>("fullname");
        }

    }
}
