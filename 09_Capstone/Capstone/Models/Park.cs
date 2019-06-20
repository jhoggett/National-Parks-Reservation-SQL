﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateEstablished { get; set; }
        public int Area { get; set; }
        public int TotalVisitors { get; set; }
        public string Description { get; set; }

        //public override string ToString()
        //{
        //    return ParkId + Name + Location + DateEstablished + Area + TotalVisitors + Description;
        //}
    }
}
