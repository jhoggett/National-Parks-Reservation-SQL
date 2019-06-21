using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ReservationSqlDAO : IReservationDAO
    {
        private string connectionString;
        public ReservationSqlDAO (string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }


        public int AddNewReservation(Reservation newReservation)
        {
            //try
            //{                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert Into reservation (site_id, name, from_date, to_date, create_ date) " +
                        "Values (@site_id, @name, @from_date, @to_date, @create_date", conn);
                    cmd.Parameters.AddWithValue("@site_id", newReservation.SiteId);
                    cmd.Parameters.AddWithValue("@name", newReservation.Name);
                    cmd.Parameters.AddWithValue("@from_date", newReservation.FromDate);
                    cmd.Parameters.AddWithValue("@to_date", newReservation.ToDate);
                    cmd.Parameters.AddWithValue("@create_date", newReservation.CreateDate);

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Select MAX(reservation_id) From reservation", conn);
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    return id;
                }
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine("Error Making Reservation.");
            //    Console.WriteLine(ex.Message);
            //    //throw;
            //}
        }
    }
}
