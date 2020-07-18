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

        public string AnalyzeAcessModifiers(string className)
        {
            var sb = new StringBuilder();
            var classType = Type.GetType(className);
            var classFields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            var publicMethods = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var nonPublicMethods = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo classField in classFields)
            {
                sb.AppendLine($"{classField.Name} must be private!");
            }

            foreach (MethodInfo publicMethod in publicMethods
                .Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{publicMethod.Name} have to be public!");
            }

            foreach (MethodInfo nonPublicMethod in nonPublicMethods
                .Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{nonPublicMethod.Name} have to be public!");
            }
            
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();
            var classType = Type.GetType(className);
            var nonPublicMethods = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo nonPublicMethod in nonPublicMethods)
            {
                sb.AppendLine(nonPublicMethod.Name);
            }

            return sb.ToString().Trim();
        }
    }
}