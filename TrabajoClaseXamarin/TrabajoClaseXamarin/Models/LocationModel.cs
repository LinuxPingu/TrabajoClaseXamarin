using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoClaseXamarin.Models
{
    public class LocationModel
    {

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string TimeZone { get; set; }

        public LocationModel()
        {
        }

        public LocationModel(string street, string city, string state, string country, string timeZone)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            TimeZone = timeZone;
        }
    }
}
