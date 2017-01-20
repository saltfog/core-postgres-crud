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
            Connection.Execute("INSERT INTO upfall (name, open_to_public, county_id description, confirmeddate) VALUES(@Name, @Open_To_Public, @County_Id @Description, @ConfirmedDate)", item);

        }

        public IEnumerable<Falls> FindAll()
        {

            return Connection.Query<Falls>("SELECT * FROM upfall f order by f.name ASC");

        }

        public Falls FindByID(int id)
        {

            return Connection.Query<Falls>("SELECT * FROM upfall WHERE id = @Id", new { Id = id }).FirstOrDefault();

        }

        public void Remove(int id)
        {
            Connection.Execute("DELETE FROM upfall WHERE Id = @Id", new { Id = id });

        }

        public void Update(Falls item)
        {
            Connection.Query("UPDATE upfall SET name = @Name, datum = @Datum, zone = @Zone, northing = @Northing, easting = @Easting, lat_lon = @Lat_Lon, county_id = @County_Id, open_to_public = @Open_To_Public, owner_id = @Owner_Id, description = @Description, confirmed_date = @Confirmed_Date WHERE id = @Id", item);

        }

        public Falls CheckForDuplicates(string name)
        {

           return Connection.Query<Falls>("SELECT name FROM upfall WHERE name = @Name", new { Name = name }).FirstOrDefault();

        }
    }
}
