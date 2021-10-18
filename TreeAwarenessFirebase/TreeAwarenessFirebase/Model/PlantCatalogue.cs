using System;
using System.Collections.Generic;
using System.Text;

namespace TreeAwareness.Model
{
   public class PlantCatalogue
    {
        public int TreeCode { get; set; }
        public string Name { get; set; }
        public string InitialIdentification { get; set; }
        public string Notes { get; set; }
        public string GPSCoordinates { get; set; }
        public string Location { get; set; }
        public string Landmark { get; set; }
        public string Height { get; set; }
        public string Canopy { get; set; }

        public string Image { get; set; }
    }
}
