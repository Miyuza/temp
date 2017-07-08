using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WorkFlowManagement.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Request> Get()
        {
            var en = new WorkFlow_ManagementEntities();
            var lst = en.Requests.ToList();
            return lst;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}