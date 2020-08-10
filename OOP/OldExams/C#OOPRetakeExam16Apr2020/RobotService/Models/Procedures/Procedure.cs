namespace RobotService.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Procedures.Contracts;
    using Robots.Contracts;
    using Utilities.Messages;

    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            Robots = new List<IRobot>();
        }

        protected IList<IRobot> Robots { get; }

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var robot in Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
        }
    }
}