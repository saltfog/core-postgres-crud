using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using ASPCoreSample.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;
using Dapper;

namespace ASPCoreSample.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : ApiController
    {
        private string connectionString;
        public CitiesController(IConfiguration configuration)
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
        // GET api/<controller>
        public IEnumerable<City> Get()
        {
            var cities = Connection.Query<City>("SELECT * FROM City");
            return cities;
        }

        // GET api/<controller>/5
        public City Get(int id)
        {
            var city = Connection.Query<City>("SELECT * FROM City WHERE ID = @id", new { id }).FirstOrDefault();
            return city;
        }

        // POST api/<controller>
        public void Post(City value)
        {

            Connection.Execute("INSERT INTO City (CountryCode, District, Name, Population) VALUES (@CountryCode, @District, @Name, @Population)",
                new
                {
                    value.CountryCode,
                    District = "",
                    value.Name,
                    value.Population,
                });

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            if (id <= 4079) throw new Exception("Cannot edit cities that came with the database");
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            if (id <= 4079) throw new Exception("Cannot delete cities that came with the database");
            Connection.Execute("DELETE FROM City WHERE Id = @id",
                new
                {
                    id
                });

        }
    }
}