using System;
using System.Collections.Generic;
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

        public IList<Site> GetSitesByCampgroundId(int campgroundId)
        {
            throw new NotImplementedException();
        }
    }
}
