using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DublinBikes.Models
{
    public class BikeGenreViewModel
    {
        public List<BikeStation> BikeStations { get; set; }
        public SelectList Names { get; set; }
        public string BikeStationName { get; set; }
        public string SearchString { get; set; }
    }
}