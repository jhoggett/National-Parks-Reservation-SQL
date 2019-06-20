using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    public class ParksMenu : CLIMenu
    {
        //Define DAOs
        IParkDAO parkDAO;
        ICampgroundDAO campgroundDAO;
        ISiteDAO siteDAO;
        IReservationDAO reservationDAO;

        private IList<Park> parks;
        public ParksMenu(IParkDAO parkDAO) : base()
        {
            this.Title = "List of park names";
            parks = parkDAO.GetParks();
            for (int i = 0; i < parks.Count; i++)
            {
                this.menuOptions.Add($"{i + 1}", $"{parks[i].Name}");
            }
            this.menuOptions.Add("Q", "Quit");
        }

        protected override bool ExecuteSelection(string choice)
        {
            int indexChoice = int.Parse(choice);
            indexChoice--;
            Park parkChoice = parks[indexChoice];

            CampGroundMenu menu = new CampGroundMenu(parkChoice, parkDAO, campgroundDAO, siteDAO, reservationDAO);
            menu.Run();
            return true;

        }
    }
}
