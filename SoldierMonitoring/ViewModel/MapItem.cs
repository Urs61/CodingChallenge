using SoldierMonitoring.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldierMonitoring.ViewModel
{
    public class MapItem : INotifyPropertyChanged
    {
        private GeoCoordinate _geoCoordinate;

        public MapItem(Soldier item)
        {
            ItemId = item.SoldierId;
            Location = item.CurrentLocation;
            FirstName = item.FirstName;
            LastName = item.LastName;
            Rank = item.Rank;
        }

        public int ItemId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }

        public GeoCoordinate Location
        {
            get => _geoCoordinate;
            set
            {
                _geoCoordinate = value;
                RaisePropertyChanged("Location");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
