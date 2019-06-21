using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class SiteSqlDAO : ISiteDAO
    {
        private string connectionString;
        public SiteSqlDAO (string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public Site GetSiteById(int siteId)
        {
            throw new NotImplementedException();
        }

        public IList<Site> GetSitesByCampgroundId(int campgroundId, DateTime arrival, DateTime departure)
        {
            List<Site> list = new List<Site>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "Select * From site Where campground_id = @campground_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@campground_id", campgroundId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Site obj = new Site();
                        obj.CampgroundId = Convert.ToInt32(reader["campground_id"]);
                        obj.SiteId = Convert.ToInt32(reader["site_id"]);
                        obj.SiteNumber = Convert.ToInt32(reader["site_number"]);
                        obj.MaxOccupants = Convert.ToInt32(reader["max_occupancy"]);
                        obj.Accessible = Convert.ToBoolean(reader["accessible"]);
                        obj.MaxRvLength = Convert.ToInt32(reader["max_rv_length"]);
                        obj.Utitlities = Convert.ToBoolean(reader["utilities"]);
                        list.Add(obj);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error in GetSitesByCampgroundId: {ex.Message}");
            }
            return list;
        }

        private Campground RowToObject(SqlDataReader row)
        {
            Campground obj = new Campground();
            obj.CampgroundId = Convert.ToInt32(row["CampgroundId"]);
            obj.ParkId = Convert.ToInt32(row["ParkId"]);
            obj.Name = Convert.ToString(row["Name"]);
            obj.OpenFromDate = Convert.ToInt32(row["OpenFromDate"]);
            obj.OpenToDate = Convert.ToInt32(row["OpenToDate"]);
            obj.DailyFee = Convert.ToDecimal(row["DailyFee"]);
            return obj;
        }
    }
}
