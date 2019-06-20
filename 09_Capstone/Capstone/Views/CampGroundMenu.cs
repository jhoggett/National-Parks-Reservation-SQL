using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    public class CampGroundMenu : CLIMenu   
    {
        //Define DAOs
        IParkDAO parkDAO;
        ICampgroundDAO campgroundDAO;
        ISiteDAO siteDAO;
        IReservationDAO reservationDAO;

        Park parkSelection;
        Campground campground;
        IList<Campground> campgrounds;
        //public CampGroundMenu(int selectedPark)
        public CampGroundMenu(Park parkSelection, IParkDAO parkDAO, ICampgroundDAO campgroundDAO, ISiteDAO siteDAO, IReservationDAO reservationDAO) : base()
        {
            this.parkSelection = parkSelection;
            this.Title = $"Campground in {parkSelection.Name}";
            this.menuOptions.Add("1", "View Campgrounds");
            this.menuOptions.Add("2", "Return to previous screen");
            
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
            switch (choice)
            {
                case "1":
                    // Display Campgrounds
                    campgrounds = campgroundDAO.GetCampgroundsByParkId(parkSelection.ParkId);
                    return true;
                case "2":
                    // Return to previous menu
                    ParksMenu menu = new ParksMenu(parkDAO);
                    menu.Run();
                    break;                 
            }
            return true;
        }
    }
}
