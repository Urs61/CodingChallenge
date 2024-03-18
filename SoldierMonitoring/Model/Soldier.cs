using System.ComponentModel;
using System.Windows.Media;
using System.Device.Location;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System;

namespace SoldierMonitoring.Model
{
    public class Soldier
    {

        private int _maxEntries;

        public Soldier(int id, int maxPathEntries)
        {
            SoldierId = id;
            _maxEntries = maxPathEntries;
        }

        public int SoldierId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public GeoCoordinate CurrentLocation { get; set; }
        public List<Location> Path { get; set; } = new List<Location>();

        public void SetCurrentPosition(GeoCoordinate position, DateTime timestamp)
        {
            if (Path.Count > _maxEntries)
            {
                Path.Clear();
            }
            Path.Add(new Location() { Position = position, TimeStamp = timestamp });
            CurrentLocation = position;
        }

    }
}
