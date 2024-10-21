using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot.Common;
using System.Collections.Generic;

namespace BunkoNazar.RobotChallange.Tests
{
    [TestClass]
    public class BunkoNazarTests
    {
        [TestMethod]
        public void Test_FindNearestAvailableStation_FindsNearestStation()
        {
            var algorithm = new BunkoNazar();
            Map map = new Map();
            map.Stations.Add(new EnergyStation { Position = new Position(0, 0) });
            map.Stations.Add(new EnergyStation { Position = new Position(5, 5) });

            var robot = new Robot.Common.Robot { Position = new Position(1, 1), Energy = 500 };
            var robots = new List<Robot.Common.Robot> { robot };

            var nearestStation = algorithm.FindNearestAvailableStation(robot, map, robots);

            Assert.AreEqual(new Position(0, 0), nearestStation.Position);
        }

        [TestMethod]
        public void Test_DoStep_CollectEnergyCommand_WhenOnStation()
        {
            var algorithm = new BunkoNazar();
            Map map = new Map();
            map.Stations.Add(new EnergyStation { Position = new Position(0, 0) });

            var robot = new Robot.Common.Robot { Position = new Position(0, 0), Energy = 300 };
            var robots = new List<Robot.Common.Robot> { robot };

            var command = algorithm.DoStep(robots, 0, map);

            Assert.IsInstanceOfType(command, typeof(CollectEnergyCommand));
        }

        [TestMethod]
        public void Test_DoStep_CreateNewRobotCommand_WhenEnoughEnergy()
        {
            var algorithm = new BunkoNazar();
            Map map = new Map();
            map.Stations.Add(new EnergyStation { Position = new Position(0, 0) });
            var robot = new Robot.Common.Robot { Position = new Position(0, 0), Energy = 1200 };
            var robots = new List<Robot.Common.Robot> { robot };

            var command = algorithm.DoStep(robots, 0, map);

            Assert.IsInstanceOfType(command, typeof(CreateNewRobotCommand));
        }

        [TestMethod]
        public void Test_FindNearestAvailableStation_StationOccupiedByAnotherOwner()
        {
            var algorithm = new BunkoNazar();
            Map map = new Map();
            map.Stations.Add(new EnergyStation { Position = new Position(0, 0) });
            var robot = new Robot.Common.Robot { Position = new Position(5, 5), Energy = 800 };
            var robots = new List<Robot.Common.Robot>
            {
                new Robot.Common.Robot { Position = new Position(0, 0), OwnerName = "AnotherOwner" },
                robot
            };

            var nearestStation = algorithm.FindNearestAvailableStation(robot, map, robots);

            Assert.AreEqual(new Position(0, 0), nearestStation.Position);
        }

        [TestMethod]
        public void Test_DoStep_MoveCommand_WhenNotOnStation()
        {
            var algorithm = new BunkoNazar();
            Map map = new Map();
            map.Stations.Add(new EnergyStation { Position = new Position(5, 5) });
            var robot = new Robot.Common.Robot { Position = new Position(0, 0), Energy = 500 };
            var robots = new List<Robot.Common.Robot> { robot };

            var command = algorithm.DoStep(robots, 0, map);

            Assert.IsInstanceOfType(command, typeof(MoveCommand));
        }

        [TestMethod]
        public void Test_GetDistance_CorrectDistanceCalculation()
        {
            var algorithm = new BunkoNazar();
            var pos1 = new Position(0, 0);
            var pos2 = new Position(3, 4);

            var distance = algorithm.GetDistance(pos1, pos2);

            Assert.AreEqual(5, distance);
        }

        [TestMethod]
        public void Test_IsStationFreeForOtherRobots_StationIsFree()
        {
            var algorithm = new BunkoNazar();
            Map map = new Map();
            map.Stations.Add(new EnergyStation { Position = new Position(0, 0) });
            var robot = new Robot.Common.Robot { Position = new Position(5, 5), Energy = 800 };
            var robots = new List<Robot.Common.Robot> { robot };

            var station = algorithm.FindNearestAvailableStation(robot, map, robots);

            Assert.AreEqual(new Position(0, 0), station.Position);
        }

        [TestMethod]
        public void Test_IsStationFreeForOtherRobots_StationIsOccupiedByAnotherRobot()
        {
            var algorithm = new BunkoNazar();
            Map map = new Map();
            map.Stations.Add(new EnergyStation { Position = new Position(0, 0) });
            var robot = new Robot.Common.Robot { Position = new Position(5, 5), Energy = 800 };
            var robots = new List<Robot.Common.Robot>
            {
                new Robot.Common.Robot { Position = new Position(0, 0), OwnerName = algorithm.Author },
                robot
            };

            var station = algorithm.FindNearestAvailableStation(robot, map, robots);

            Assert.IsNull(station);
        }

        [TestMethod]
        public void Test_CheckStation_RobotIsOnStation()
        {
            var algorithm = new BunkoNazar();
            Map map = new Map();
            map.Stations.Add(new EnergyStation { Position = new Position(0, 0) });
            var robot = new Robot.Common.Robot { Position = new Position(0, 0), Energy = 800 };

            bool isOnStation = algorithm.CheckStation(robot, map);

            Assert.IsTrue(isOnStation);
        }

        [TestMethod]
        public void Test_CheckStation_RobotIsNotOnStation()
        {
            var algorithm = new BunkoNazar();
            Map map = new Map();
            map.Stations.Add(new EnergyStation { Position = new Position(0, 0) });
            var robot = new Robot.Common.Robot { Position = new Position(1, 1), Energy = 800 };

            bool isOnStation = algorithm.CheckStation(robot, map);

            Assert.IsFalse(isOnStation);
        }
    }
}
