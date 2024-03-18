using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldierMonitoring.Model
{
    public class SensorData
    {
        public int SoldierId { get; set; }
        public GeoCoordinate Location { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
