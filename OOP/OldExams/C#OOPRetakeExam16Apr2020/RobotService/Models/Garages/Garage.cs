namespace RobotService.Models.Garages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Robots.Contracts;
    using Utilities.Messages;

    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private Dictionary<string, IRobot> _robots;

        public Garage()
        {
            _robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => _robots;

        public void Manufacture(IRobot robot)
        {
            if(Robots.Count == Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);

            if(Robots.ContainsKey(robot.Name))
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));

            _robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!Robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            var robot = _robots[robotName];
            robot.Owner = ownerName;
            robot.IsBought = true;
            _robots.Remove(robotName);
        }
    }
}