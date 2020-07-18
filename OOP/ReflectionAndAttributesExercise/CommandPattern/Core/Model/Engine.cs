namespace CommandPattern.Core.Model
{
    using Contracts;

    public class Engine : IEngine
    {
        public Engine(ICommandInterpreter command)
        {

        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}