using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlbanianXrm.WebAPI.Integration.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        IOrganizationService organizationService;

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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
