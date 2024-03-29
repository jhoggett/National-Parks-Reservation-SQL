﻿using Capstone.DAL;
using Capstone.Views;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Project");
            ParkSqlDAO parkDAO = new ParkSqlDAO(connectionString);
            CampgroundSqlDAO campgroundDAO = new CampgroundSqlDAO(connectionString);
            ReservationSqlDAO reservationDAO = new ReservationSqlDAO(connectionString);
            SiteSqlDAO siteDAO = new SiteSqlDAO(connectionString);

            



            // Create a menu and run it
            ParksMenu menu = new ParksMenu(parkDAO, campgroundDAO, reservationDAO, siteDAO);
            menu.Run();
        }
    }
}
