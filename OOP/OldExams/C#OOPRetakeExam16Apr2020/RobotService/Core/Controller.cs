namespace RobotService.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Garages;
    using Models.Garages.Contracts;
    using Models.Procedures;
    using Models.Procedures.Contracts;
    using Models.Robots;
    using Models.Robots.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IGarage _garage;
        private IList<IProcedure> _procedures;

        public Controller()
        {
            _garage = new Garage();
            _procedures = new List<IProcedure>();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!Enum.TryParse(robotType, out RobotsType type))
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));

            IRobot robot = null;
            switch (type)
            {
                case RobotsType.HouseholdRobot:
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotsType.PetRobot:
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotsType.WalkerRobot:
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
            }

            _garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            IProcedure procedure = _procedures.FirstOrDefault(p => p.GetType().Name == nameof(Chip));

            if (procedure == null)
                procedure = new Chip();

            procedure.DoService(robot, procedureTime);
            _procedures.Add(procedure);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            IProcedure procedure = _procedures.FirstOrDefault(p => p.GetType().Name == nameof(TechCheck));

            if (procedure == null)
                procedure = new TechCheck();

            procedure.DoService(robot, procedureTime);
            _procedures.Add(procedure);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            IProcedure procedure = _procedures.FirstOrDefault(p => p.GetType().Name == nameof(Rest));

            if (procedure == null)
                procedure = new Rest();

            procedure.DoService(robot, procedureTime);
            _procedures.Add(procedure);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            IProcedure procedure = _procedures.FirstOrDefault(p => p.GetType().Name == nameof(Work));

            if (procedure == null)
                procedure = new Work();

            procedure.DoService(robot, procedureTime);
            _procedures.Add(procedure);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            IProcedure procedure = _procedures.FirstOrDefault(p => p.GetType().Name == nameof(Charge));

            if (procedure == null)
                procedure = new Charge();

            procedure.DoService(robot, procedureTime);
            _procedures.Add(procedure);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = GetRobot(robotName);
            IProcedure procedure = _procedures.FirstOrDefault(p => p.GetType().Name == nameof(Polish));

            if (procedure == null)
                procedure = new Polish();

            procedure.DoService(robot, procedureTime);
            _procedures.Add(procedure);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetRobot(robotName);
            _garage.Sell(robotName, ownerName);

            if(robot.IsChipped)
                return string.Format(OutputMessages.SellChippedRobot, ownerName);

            return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string History(string procedureType)
        {
            var procedure = _procedures
                .FirstOrDefault(p => p.GetType().Name == procedureType);
            
            return procedure.History();
        }

        private IRobot GetRobot(string robotName)
        {
            if (!_garage.Robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            return _garage.Robots[robotName];
        }
    }
}