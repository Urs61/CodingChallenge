using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SoldierMonitoring.Model;
using SoldierMonitoring.Services;

namespace SoldierMonitoring.ViewModel
{
    public class MapViewModel
    {
        private LocationService _locationService;

        public ObservableCollection<MapItem> MapItems { get; set; }

        public MapViewModel()
        {
            MapItems = new ObservableCollection<MapItem>();
            _locationService = new LocationService();
            _locationService.ItemAdded += OnItemAdded;
            _locationService.ItemLocationUpdated += OnLocationUpdated;

            _locationService.StartService();
        }

        private void OnItemAdded(Soldier item)
        {
            MapItems.Add(new MapItem(item));
        }

        private void OnLocationUpdated(int id, GeoCoordinate newLocation)
        {
            var item = MapItems.FirstOrDefault(i => i.ItemId == id);
            if (item != null)
            {
                var dispatcher = Application.Current?.Dispatcher;
                if (dispatcher != null)
                {
                    dispatcher.Invoke(() => item.Location = newLocation);
                }
            }
        }

    }
}
