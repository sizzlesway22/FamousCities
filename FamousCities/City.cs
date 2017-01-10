using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FamousCities
{
    class City
    {
        public string name { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public int imageSrc { get; set; }

        public City(string _name, string _country, string _description, int _imageSrc)
        {
            name = _name;
            country = _country;
            description = _description;
            imageSrc = _imageSrc;

        }
    }
}