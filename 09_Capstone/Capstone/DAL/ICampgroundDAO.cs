using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface ICampgroundDAO
    {
        Campground GetCampgroundById(int campgroundId);

        IList<Campground> GetCampgroundsByParkId(int parkId);
    }
}
