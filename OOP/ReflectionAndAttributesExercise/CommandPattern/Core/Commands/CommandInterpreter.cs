namespace CommandPattern.Core.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string classSuffix = "Command";
        public string Read(string args)
        {
            ICommand command = null;
            var commandName = $"{args.Split()[0]}{classSuffix}";
            var commandType = Assembly.GetCallingAssembly().GetTypes();
            var currentCommandType = commandType
                .Where(t => t.GetInterfaces().Any(i => i.Name == nameof(ICommand)))
                .FirstOrDefault(t => t.Name == commandName);

            if(currentCommandType == null)
                throw new InvalidOperationException("Invalid command name!");

            var obj = Activator.CreateInstance(currentCommandType) as ICommand;

            return obj.Execute(args.Split().Skip(1).ToArray());
        }
    }
}