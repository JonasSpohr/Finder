﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopFinder
{
    class TextSearchAPI
    {
        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
        }

        public class OpeningHours
        {
            public bool open_now { get; set; }
            public List<object> weekday_text { get; set; }
        }

        public class Photo
        {
            public int height { get; set; }
            public List<string> html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }

        public class Result
        {
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string icon { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string place_id { get; set; }
            public string reference { get; set; }
            public List<string> types { get; set; }
            public OpeningHours opening_hours { get; set; }
            public List<Photo> photos { get; set; }
            public double? rating { get; set; }
        }

        public class RootObject
        {
            public List<object> html_attributions { get; set; }
            public string next_page_token { get; set; }
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
    }
}
