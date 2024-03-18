using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldierMonitoring.Model
{
    public class SoldierRepo
    {
        public List<Soldier> Soldiers { get; }
        public SoldierRepo()
        {
            Soldiers = new List<Soldier>();
        }

        public Soldier GetSoldier(int id)
        {
            return Soldiers.FirstOrDefault(s => s.SoldierId == id);
        }

        public void CreateSoldiers(int numbers, GeoCoordinate initialLocation)
        {
            for (int i = 1; i <= numbers; i++)
            {
                AddSoldier(new Soldier(i, 30)
                {
                    CurrentLocation = initialLocation,
                    FirstName = "FirstName_" + 1,
                    LastName = "LastName_" + 1,
                    Rank = "Std"
                });
            }
        }

        public void AddSoldier(Soldier soldier)
        {
            Soldiers.Add(soldier);
        }

        public void RemoveSoldier(int id)
        {
            //....
        }
        public void RemoveSoldier(Soldier soldier)
        {
            //....
        }

    }
}
