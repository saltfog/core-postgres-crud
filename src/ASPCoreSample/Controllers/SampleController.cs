using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPCoreSample.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;
using Dapper;

namespace ASPCoreSample.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        private string connectionString;

        public SampleController(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Falls> Get()
        {
            var falls = new List<Falls>();
            var str = Connection.Query<Falls>("SELECT * FROM upfall").AsList();
            return str;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
