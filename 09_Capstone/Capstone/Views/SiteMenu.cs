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
            this.menuOptions.Add("Q", "Go Back");
        }

        protected override void DisplayBeforeMenu()
        {
            Console.WriteLine("         Name         Open        Close       Daily Fee");
            foreach (Campground campground in campgrounds)
            {
                Console.WriteLine($"{campground.CampgroundId,-1}      {campground.Name, -1}      {campground.OpenFromDate, -1}      {campground.OpenToDate, -1}        {campground.DailyFee, -1}");
            }
            
        }

        protected override bool ExecuteSelection(string choice)
        {
            //Console.WriteLine("Select a Campground number to search for reservations:");
            //string selectedCampground = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();


                //Console.WriteLine("Search for Campground Reservation");
                Console.WriteLine("         Name         Open        Close       Daily Fee");
                foreach (Campground campground in campgrounds)
                {
                    Console.WriteLine($"{campground.CampgroundId,-1}      {campground.Name,-1}      {campground.OpenFromDate,-1}      {campground.OpenToDate,-1}        {campground.DailyFee,-1}");

                }
                // Asks user for campground and reservation start and end date to get available sites
                Console.WriteLine("===================================================");
                Console.WriteLine("\nEnter Q to go back");
                Console.Write("\nPlease Select a Campground Number: ");
                string campgroundChoice = Console.ReadLine();
                Console.Write("\nWhat is the arrival date? MM/DD/YYYY: ");
                string arrivalDate = Console.ReadLine();
                Console.Write("\nWhat is the departure date? MM/DD/YYYY: ");
                string departureDate = Console.ReadLine();

                int campId = int.Parse(campgroundChoice);
                DateTime arrival = DateTime.Parse(arrivalDate);
                DateTime departure = DateTime.Parse(departureDate);
                Console.Clear();

                Console.WriteLine("Available Campsites matching your search criteria");
                Console.WriteLine("\n=================================================");

                Console.WriteLine("Site No.     Max Occupancy       Accessible      Max RV Length       Utility     Cost");
                IList<Site> sites = siteDAO.GetSitesByCampgroundId(campId, arrival, departure);
                foreach(Site site in sites)
                {
                    Console.WriteLine($"{site.SiteNumber}      {site.MaxOccupants}      {site.Accessible}       {site.MaxRvLength}      {site.Utilities}       ");
                }
                Console.Write("\nWhich site should be reserved? ");
                string reserveSelection = Console.ReadLine();
                int reservationSite = int.Parse(reserveSelection);
                Console.Write("\nWhat name should the reservation be made under? ");
                string reservationName = Console.ReadLine();
                

                Reservation reservation = new Reservation
                {
                    SiteId = reservationSite,
                    Name = reservationName,
                    FromDate = arrival,
                    ToDate = departure,
                    CreateDate = DateTime.Now
                };
                reservationDAO.AddNewReservation(reservation);
                Console.WriteLine($"The reservation has been made. Your confirmation id is {reservation.ReservationId}");
                Pause("Press Enter to go back");
                return true;
            }
            return true;
        }
    }
}
