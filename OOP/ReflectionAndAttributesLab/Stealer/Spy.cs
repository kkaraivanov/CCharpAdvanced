namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            var classType = Type.GetType(className);
            var classFields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            var sb = new StringBuilder();
            Object obj = Activator.CreateInstance(classType, new object?[] { });
            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo classField in classFields
                .Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{classField.Name} = {classField.GetValue(obj)}");
            }

            return sb.ToString().Trim();
        }
    }
}