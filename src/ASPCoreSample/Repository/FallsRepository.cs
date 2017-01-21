using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Npgsql;
using ASPCoreSample.Models;

namespace ASPCoreSample.Repository
{
    public class FallsRepository
    {
        private string connectionString;
        public FallsRepository(IConfiguration configuration)
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

        public void Add(Falls item)
        {
            Connection.Execute("INSERT INTO upfall (id, name, open_to_public, description, confirmed_date) VALUES (@Name, @Open_To_Public, @Description, @Confirmed_Date)", item);

        }

        public IEnumerable<Falls> FindAll()
        {

            return Connection.Query<Falls>("SELECT * FROM upfall f order by f.name ASC");

        }

        public Falls FindByID(int id)
        {

            return Connection.Query<Falls>("SELECT * FROM upfall WHERE id = @id", new { id = id }).FirstOrDefault();

        }

        public void Remove(int id)
        {
            Connection.Execute("DELETE FROM upfall WHERE id = @id", new { id = id });

        }

        public void Update(Falls item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                Connection.Execute("UPDATE upfall SET name = @name, datum = @datum, zone = @zone, northing = @northing, easting = @easting, lat_lon = @lat_lon, county_id = @county_id, open_to_public = @open_to_public, owner_id = @Owner_Id, description = @description, confirmed_date = @confirmed_date WHERE id = @id", item);
            }

        }

        public Falls CheckForDuplicates(string name)
        {

           return Connection.Query<Falls>("SELECT name FROM upfall WHERE name = @name", new { name = name }).FirstOrDefault();

        }
    }
}
