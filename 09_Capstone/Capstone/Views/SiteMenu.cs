using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    public class SiteMenu : CLIMenu
    {
        protected Park park;
        protected IList<Campground> campgrounds;
        protected SiteSqlDAO SiteSqlDAO;
        protected Site site;
        public SiteMenu(IList<Campground> campgroundsList, Park parkSelection, IParkDAO parkDAO, ICampgroundDAO campgroundDAO, IReservationDAO reservationDAO, ISiteDAO siteDAO) : base(parkDAO, campgroundDAO, reservationDAO, siteDAO)
        {
            this.campgrounds = campgroundsList;
            this.park = parkSelection;
            this.Title = $"{park.Name} National Park Campgrounds";
            this.menuOptions.Add("1", "Search for Available Reservation");
            this.menuOptions.Add("Q", "Return to previous screen");
        }

        protected override void DisplayBeforeMenu()
        {
            foreach (Campground campground in campgrounds)
            {
                Console.WriteLine($"{campground.CampgroundId,-1}      {campground.Name, -1}      {campground.OpenFromDate, -1}      {campground.OpenToDate, -1}        {campground.DailyFee, -1}");

            }
        }

        protected override bool ExecuteSelection(string choice)
        {
            throw new NotImplementedException();
        }
    }
}
