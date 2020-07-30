namespace CommandPattern
{
    using Core;
    using Core.Commands;
    using Core.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
