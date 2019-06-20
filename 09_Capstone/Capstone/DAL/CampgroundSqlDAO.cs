using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    

    public class CampgroundSqlDAO : ICampgroundDAO
    {
        private string connectionString;
        public CampgroundSqlDAO (string databaseConncetionString)
        {
            connectionString = databaseConncetionString;
        }

        // May not need this method ask Mike
        public Campground GetCampgroundById(int campgroundId)
        {
            // List to hold Campground object
            Campground obj = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "Select name From campground Where campground_id = @campgroundIdToSearchFor or @campgroundIdToSearchFor = ''";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@campgroundIdToSearchFor", campgroundId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = RowToObject(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error in GetCampgroundByCampgroundId: {ex.Message}");
            }
            return obj;
        }

        public IList<Campground> GetCampgroundsByParkId(int parkId)
        {
            // List to hold Campground object
            List<Campground> list = new List<Campground>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "Select * From campground Where park_id = @parkIdToSearchFor or @parkIdToSearchFor = ''";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkIdToSearchFor", parkId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campground obj = RowToObject(reader);

                        list.Add(obj);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error in GetCampgroundByParkId: {ex.Message}");
            }
            return list;
        }

        private Campground RowToObject(SqlDataReader row)
        {
            Campground obj = new Campground();
            obj.CampgroundId = Convert.ToInt32(row["CampgroundId"]);
            obj.ParkId = Convert.ToInt32(row["ParkId"]);
            obj.Name = Convert.ToString(row["Name"]);
            obj.OpenFromDate = Convert.ToDateTime(row["OpenFromDate"]);
            obj.OpenToDate = Convert.ToDateTime(row["OpenToDate"]);
            obj.DailyFee = Convert.ToDecimal(row["DailyFee"]);
            return obj;
        }
    }
}
