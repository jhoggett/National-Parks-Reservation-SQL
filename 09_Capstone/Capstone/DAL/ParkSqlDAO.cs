using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;

        public ParkSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
            
        }
        public IList<Park> GetParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                // Create connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create query and command object
                    string sql = "SELECT * FROM park";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute and get reader back
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read each row
                    while (reader.Read())
                    {
                        // Create new object
                        Park obj = RowToObject(reader);

                        // Add Park to list
                        parks.Add(obj);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error in GetParks: {ex.Message}");
            }
            return parks;
        }

        private Park RowToObject(SqlDataReader row)
        {
            Park obj = new Park();
            obj.Name = Convert.ToString(row["Name"]);
            obj.ParkId = Convert.ToInt32(row["Park_Id"]);
            obj.Location = Convert.ToString(row["Location"]);
            obj.Area = Convert.ToInt32(row["Area"]);
            obj.DateEstablished = Convert.ToDateTime(row["establish_date"]);
            obj.Description = Convert.ToString(row["Description"]);
            obj.TotalVisitors = Convert.ToInt32(row["Visitors"]);
            return obj;
        }
    }
}
