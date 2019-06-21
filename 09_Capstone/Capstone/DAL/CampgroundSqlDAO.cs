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

                    string sql = "Select name From campground Where campground_id = @campgroundIdToSearchFor";
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

                    string sql = "Select * From campground Where park_id = @park_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@park_id", parkId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campground obj = new Campground();
                        obj.CampgroundId = Convert.ToInt32(reader["campground_id"]);
                        obj.ParkId = Convert.ToInt32(reader["park_id"]);
                        obj.Name = Convert.ToString(reader["name"]);
                        obj.OpenFromDate = Convert.ToInt32(reader["open_from_mm"]);
                        obj.OpenToDate = Convert.ToInt32(reader["open_to_mm"]);
                        obj.DailyFee = Convert.ToDecimal(reader["daily_fee"]);
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
            obj.OpenFromDate = Convert.ToInt32(row["OpenFromDate"]);
            obj.OpenToDate = Convert.ToInt32(row["OpenToDate"]);
            obj.DailyFee = Convert.ToDecimal(row["DailyFee"]);
            return obj;
        }
    }
}
