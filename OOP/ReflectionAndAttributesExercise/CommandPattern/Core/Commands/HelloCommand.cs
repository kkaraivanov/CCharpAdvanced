namespace CommandPattern.Core.Commands
{
    using System;
    using Interfaces;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}