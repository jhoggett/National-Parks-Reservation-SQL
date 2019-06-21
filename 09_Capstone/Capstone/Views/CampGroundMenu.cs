using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    public class CampGroundMenu : CLIMenu   
    {

        protected Park parkSelection;
        protected CampgroundSqlDAO campgroundSqlDAO;
        protected Campground campground;
        
        //public CampGroundMenu(int selectedPark)
        public CampGroundMenu(Park parkSelection, IParkDAO parkDAO, ICampgroundDAO campgroundDAO, IReservationDAO reservationDAO, ISiteDAO siteDAO) : base(parkDAO, campgroundDAO, reservationDAO, siteDAO)
        {
            this.parkSelection = parkSelection;
            this.Title = $"Campground in {parkSelection.Name}";
            this.menuOptions.Add("1", "View Campgrounds");
            this.menuOptions.Add("Q", "Return to previous screen");
            
        }

        protected override void DisplayBeforeMenu()
        {
            Console.WriteLine($"{parkSelection.Name} National Park");
            Console.WriteLine($"Location:           {parkSelection.Location}");
            Console.WriteLine($"Established:        {parkSelection.DateEstablished}");
            Console.WriteLine($"Area:               {parkSelection.Area} km");
            Console.WriteLine($"Annual Visitors:    {parkSelection.TotalVisitors}");
            Console.WriteLine();
            Console.WriteLine($"{parkSelection.Description}");
        }

        protected override bool ExecuteSelection(string choice)
        {
            IList<Campground> campgrounds = campgroundDAO.GetCampgroundsByParkId(parkSelection.ParkId);

            foreach(Campground campground in campgrounds)
            {
                Console.WriteLine($"{campground.Name}");
            }
            //switch (choice)
            //{
            //    case "1":
            //        Display Campgrounds
            //        campgrounds = campgroundDAO.GetCampgroundsByParkId(parkSelection.ParkId);
            //        return true;
            //    case "Q":
            //        Return to previous menu
            //        ParksMenu menu = new ParksMenu(parkDAO);
            //        menu.Run();
            //        break;
            //}
            //return true;
            return true;
        }
    }
}
