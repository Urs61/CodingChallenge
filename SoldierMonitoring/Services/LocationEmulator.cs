using SoldierMonitoring.Model;
using System;
using System.Device.Location;
using System.Timers;

namespace SoldierMonitoring.Services
{
    internal class LocationEmulator
    {
        private GeoCoordinate _mapCenter;
        private const int _maxTStep = 2000;
        private Random _random = new Random();
        private SoldierRepo _soldierRepo;
        private Timer _updateTimer;

        internal Action<SensorData> SensorDataReceived;

        public LocationEmulator(GeoCoordinate mapCenter, SoldierRepo soldierRepo, int timerInterval)
        {
            _mapCenter = mapCenter;
            _soldierRepo = soldierRepo;

            _updateTimer = new System.Timers.Timer(timerInterval);
            _updateTimer.AutoReset = true;
            _updateTimer.Elapsed += PublishLocations;
        }

        public void Start()
        {
            _updateTimer.Start();
        }

        private GeoCoordinate GetNewPosition(GeoCoordinate oldCoordinate)
        {
            double stepLat = (2000 - _random.Next(4000)) / 1000000.0;
            double stepLon = (2000 - _random.Next(4000)) / 1000000.0;
            return new GeoCoordinate(oldCoordinate.Latitude + stepLat, oldCoordinate.Longitude + stepLon);
        }

        private void PublishLocations(object sender, ElapsedEventArgs e)
        {
            foreach (var soldier in _soldierRepo.Soldiers)
            {
                SensorData sensorData = new SensorData() {Location = GetNewPosition(soldier.CurrentLocation), SoldierId = soldier.SoldierId, TimeStamp = DateTime.UtcNow};
                SensorDataReceived?.Invoke(sensorData);
            }
        }
    }
}
