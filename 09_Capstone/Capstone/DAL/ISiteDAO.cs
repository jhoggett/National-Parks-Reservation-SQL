using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface ISiteDAO
    {
        Site GetSiteById(int siteId);

        IList<Site> GetSitesByCampgroundId(int campgroundId, DateTime arrival, DateTime departure);
    }
}
