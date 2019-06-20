﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Campground
    {
        public int CampgroundId { get; set; }
        public int ParkId { get; set; }
        public string Name { get; set; }
        public DateTime OpenFromDate { get; set; }
        public DateTime OpenToDate { get; set; }
        public decimal DailyFee { get; set; }

        //public override string ToString()
        //{
        //    return CampgroundId + ParkId + Name + OpenFromDate + OpenToDate + DailyFee;
        //}
    }
}