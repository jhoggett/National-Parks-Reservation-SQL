using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    

    public class CampgroundSqlDAO : ICampgroundDAO
    {
        private string connectionString;
        public Campground GetCampgroundById(string databaseConncetionString)
        {
            connectionString = databaseConncetionString;
        }

        public IList<Campground> GetCampgroundsByParkId(int parkId)
        {
            return GetCampgroundsByParkId();
        }
    }
}
