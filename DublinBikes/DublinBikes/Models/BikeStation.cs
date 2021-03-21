﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DublinBikes.Models
{
    public class BikeStation
    {
        public int Id { get; set; }
        public string ContractName { get; set; }
        public string Name { get; set; }
        public string adress { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public bool banking { get; set; }
        public int AvailableBikes { get; set; }
        public int AvailableStands { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
    }
}
