using Robot.Common;
using System;
using System.Collections.Generic;

namespace BunkoNazar.RobotChallange
{
    public class BunkoNazar : IRobotAlgorithm
    {
        public int RobotEnergy = 800;
        public int NewRobotEnergy;
        private Dictionary<Robot.Common.Robot, EnergyStation> robotStations = new Dictionary<Robot.Common.Robot, EnergyStation>();
        public string Author => "Bunko Nazar";

        private int roundNumber = 0;

        public BunkoNazar()
        {
            Logger.OnLogRound += Logger_OnLogRound;
        }

        private void Logger_OnLogRound(object sender, LogRoundEventArgs e)
        {
            roundNumber++;
        }

        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            NewRobotEnergy = RobotEnergy - 200;
            var robot = robots[robotToMoveIndex];

            if (roundNumber >= 40 || (CheckStation(robot, map) && robot.Energy < 800) || (robots.Count == 100 && CheckStation(robot, map)))
            {
                return new CollectEnergyCommand();
            }

            if (CheckStation(robot, map))
            {
                var newRobotNearestStation = FindNearestAvailableStation(robot, map, robots);
                int distanceForNewRobot = GetDistance(robot.Position, newRobotNearestStation.Position);

                if (robot.Energy >= distanceForNewRobot + 200)
                {
                    return new CreateNewRobotCommand() { NewRobotEnergy = NewRobotEnergy };
                }

                return new CollectEnergyCommand();
            }

            var nearestStation = FindNearestAvailableStation(robot, map, robots);

            if (nearestStation == null)
            {
                return null;
            }

            var newPosition = nearestStation.Position;
            var distanceToStation = GetDistance(robot.Position, newPosition);
            var requiredEnergy = distanceToStation;

            if (robot.Energy < requiredEnergy)
            {
                return null;
            }

            return new MoveCommand() { NewPosition = newPosition };
        }

        public bool CheckStation(Robot.Common.Robot robot, Map map)
        {
            for (var i = 0; i < map.Stations.Count; i++)
            {
                if (robot.Position == map.Stations[i].Position)
                {
                    return true;
                }
            }
            return false;
        }

        public EnergyStation FindNearestAvailableStation(Robot.Common.Robot robot, Map map, IList<Robot.Common.Robot> robots)
        {
            EnergyStation nearestStation = null;
            int minDistance = int.MaxValue;

            foreach (var station in map.Stations)
            {
                bool isStationFree = true;

                foreach (var otherRobot in robots)
                {
                    if (otherRobot.Position == station.Position && otherRobot.OwnerName == Author)
                    {
                        isStationFree = false;
                        break;
                    }
                }

                if (isStationFree)
                {
                    int distance = GetDistance(robot.Position, station.Position);

                    if (distance < minDistance && (!robotStations.ContainsKey(robot) || robotStations[robot] != station))
                    {
                        minDistance = distance;
                        nearestStation = station;
                    }
                }
            }

            return nearestStation;
        }

        public int GetDistance(Position pos1, Position pos2)
        {
            return (int)Math.Sqrt(Math.Pow(pos1.X - pos2.X, 2) + Math.Pow(pos1.Y - pos2.Y, 2));
        }
    }

}