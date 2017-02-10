﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPCoreSample.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ASPCoreSample.Controllers
{
   
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

        public IActionResult Search()
        {
            return View();
        }

        // GET: api/values
        [HttpGet("api/sample")]
        public IActionResult SearchResults()
        {
            var results = Connection.Query<Search>("SELECT name FROM upfall").AsList();
            return Content(JsonConvert.SerializeObject(results, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }


        // GET api/values/5
        //[HttpGet("{id}")]
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
