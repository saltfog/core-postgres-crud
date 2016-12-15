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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPCoreSample.Controllers
{
    public class SelectorsController : Controller
    {
        private string connectionString;

        public SelectorsController(IConfiguration configuration)
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

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Message = "Multiple DropDown List";

            Selectors obj = new Selectors();

            List<WaterFalls> waterFalls = new List<WaterFalls>();
            waterFalls = WaterFallList();

            List<Description> descriptionFalls = new List<Description>();
            descriptionFalls = DescriptionList();

            SelectList waterFallListToBind = new SelectList(waterFalls, "Id", "WaterFallName", 0);
            SelectList descriptionListToBind = new SelectList(descriptionFalls, "Id", "WaterFallDescription", 0);

            obj.WaterFallList = waterFallListToBind;

            obj.DescriptionList = descriptionListToBind;

            return View(obj);
        }

        public List<WaterFalls> WaterFallList()

        {

            List<WaterFalls> waterFalls = new List<WaterFalls>();
            Connection.Query<WaterFalls>("SELECT id, name FROM upfall");
            return waterFalls;

        }

        public List<Description> DescriptionList()

        {

            List<Description> descriptionFalls = new List<Description>();
            Connection.Query<Description>("SELECT id, description FROM upfall");
            return descriptionFalls;

        }

    }
}
