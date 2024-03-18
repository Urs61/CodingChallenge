using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SoldierMonitoring.Services;
using SoldierMonitoring.Model;

namespace SoldierMonitoringUnitTest
{
    [TestClass]
    public class SoldierMonitoringUT
    {

        const int _nbrOfSoldiers = 10;

        [TestMethod]
        public void LocationService_AddSoldiers()
        {
            //Arrange
            LocationService _locationService = new LocationService();

            // Act
            for (int i = 1; i <= _nbrOfSoldiers; i++)
            {
                _locationService.AddSoldier(new Soldier(i,10));
            }

            // Assert
            Assert.IsTrue(_locationService.GetSoldierCount() == _nbrOfSoldiers, "_locationService.GetSoldierCount() == nbrOfSoldiers");
        }

        [TestMethod]
        public void LocationService_FindSoldier_Found()
        {
            //Arrange
            LocationService _locationService = new LocationService();

            // Act
            for (int i = 1; i <= _nbrOfSoldiers; i++)
            {
                _locationService.AddSoldier(new Soldier(i, 10));
            }

            var res = _locationService.GetSoldier(5);
            // Assert
            Assert.IsNotNull(res, "GetSoldier not found");
        }

        [TestMethod]
        public void LocationService_FindSoldier_NotFound()
        {
            //Arrange
            LocationService _locationService = new LocationService();

            // Act
            for (int i = 1; i <= _nbrOfSoldiers; i++)
            {
                _locationService.AddSoldier(new Soldier(i, 10));
            }

            var res = _locationService.GetSoldier(55);
            // Assert
            Assert.IsNull(res, "GetSoldier found");
        }
    }
}
