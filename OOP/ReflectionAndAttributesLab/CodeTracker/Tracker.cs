namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type typeClass = typeof(StartUp);
            MethodInfo[] methodsInfo = typeClass.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (MethodInfo method in methodsInfo)
            {
                if (method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute item in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {item.Name}");
                    }
                }
            }
        }
    }
}
