using System;
using System.Collections.Generic;
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
            return GetParks("");
        }
    }
}
