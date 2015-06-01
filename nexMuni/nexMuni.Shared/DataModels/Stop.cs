﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace nexMuni.DataModels
{
    [Table("BusStops")]
    public class Stop
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string StopName { get; set; }
        public string Routes { get; set; }
        public string StopTags { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string DistanceAsString
        {
            get { return DistanceAsDouble.ToString("F") + "mi"; }
        }
        public double DistanceAsDouble { get; private set; }

        public string stopId;
        public int favId;

        public Stop(string name, string id, string routes, string tags, double lat, double lon )
        {
            StopName = name;
            Routes = routes;
            StopTags = tags;
            Latitude = lat;
            Longitude = lon;
            stopId = id;
        }

        public Stop(string name, string routes, string tags, double lat, double lon, double distance)
        {
            StopName = name;
            Routes = routes;
            StopTags = tags;
            Latitude = lat;
            Longitude = lon;
            DistanceAsDouble = distance;
        }
    }
};
