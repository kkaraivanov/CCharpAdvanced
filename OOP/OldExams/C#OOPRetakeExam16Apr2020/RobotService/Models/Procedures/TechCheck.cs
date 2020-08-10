namespace RobotService.Models.Procedures
{
    using Robots.Contracts;

    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= 8;
            robot.IsChipped = true;
            robot.IsChipped = true;
        }
    }
}