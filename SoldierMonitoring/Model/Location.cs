using System;
using System.Device.Location;


namespace SoldierMonitoring.Model
{
    public class Location
    {
        public DateTime TimeStamp { get; set; }

        public GeoCoordinate Position { get; set; }
    }
}
