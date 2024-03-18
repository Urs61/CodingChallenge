using SoldierMonitoring.Model;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SoldierMonitoring.Services
{
    public class LocationService
    {
        private readonly LocationEmulator _locationEmulator;
        private List<Soldier> _soldiers = new List<Soldier>();
        private readonly GeoCoordinate _mapCenter = new GeoCoordinate(47.0, 7.0);
        private readonly SoldierRepo _soldierRepo = new SoldierRepo();

        private const int _timerIntervall = 3000;

        internal Action<Soldier> ItemAdded;
        internal Action<int, GeoCoordinate> ItemLocationUpdated;

        public LocationService()
        {
            _locationEmulator = new LocationEmulator(_mapCenter, _soldierRepo, _timerIntervall);
            _locationEmulator.SensorDataReceived += OnSensorDataReceived;
        }

        public void StartService()
        {
            _soldierRepo.CreateSoldiers(4, _mapCenter);
            PublishSolders();
            _locationEmulator.Start();
        }

        public void AddSoldier(Soldier soldier)
        {
            _soldierRepo.AddSoldier(soldier);
        }

        public int GetSoldierCount()
        {
            return _soldierRepo.Soldiers.Count;
        }

        public Soldier GetSoldier(int id)
        {
            return _soldierRepo.GetSoldier(id);
        }

        private void PublishSolders()
        {
            foreach (var soldier in _soldierRepo.Soldiers)
            {
                ItemAdded?.Invoke(soldier);
            }
        }

        private void OnSensorDataReceived(SensorData data)
        {
            var soldier = _soldierRepo.GetSoldier(data.SoldierId);
            if(soldier != null)
            {
                soldier.SetCurrentPosition(data.Location, data.TimeStamp);
                ItemLocationUpdated?.Invoke(data.SoldierId, data.Location);
            }
        }
    }
}
