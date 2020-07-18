namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            //var type = Assembly.GetExecutingAssembly().GetTypes();
            var methods = typeof(StartUp).GetMethods(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                .Select(x => new
                {
                    typeName = x,
                    typeAttributes = x.GetCustomAttributes<AuthorAttribute>()
                })
                .Where(x => x.typeAttributes.Any());
            //var typeAttributes = type
            //    .Select(x => new
            //    {
            //        typeName = x,
            //        typeAttributes = x.GetCustomAttributes<AuthorAttribute>()
            //    })
            //    .Where(x => x.typeAttributes.Any());

            foreach (var method in methods)
            {
                var typeName = method.typeName.Name;
                var attributes = method.typeAttributes.Select(x => x.Name);
                var attributeName = string.Join(", ", attributes);

                Console.WriteLine($"{typeName} is written by {attributeName}");
            }
        }
    }
}