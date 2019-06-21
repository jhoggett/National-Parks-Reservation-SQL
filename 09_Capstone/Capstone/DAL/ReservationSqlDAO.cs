using System;
using System.Collections.Generic;
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


        public bool AddNewReservation(Reservation newReservation)
        {
            throw new NotImplementedException();
        }
    }
}
