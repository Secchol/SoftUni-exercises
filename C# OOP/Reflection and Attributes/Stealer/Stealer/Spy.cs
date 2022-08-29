using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");
            Object instance = Activator.CreateInstance(type);
            foreach (FieldInfo field in fields.Where(x => fieldsToInvestigate.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");


            }
            return sb.ToString();


        }
        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");

            }
            foreach (MethodInfo method in publicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");

            }
            foreach (MethodInfo method in privateMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");

            }
            return sb.ToString();



        }
        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType}");
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo method in methods)
            {
                sb.AppendLine(method.Name);


            }
            return sb.ToString();



        }
        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");


            }
            foreach (MethodInfo method in methods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");


            }
            return sb.ToString();


        }
    }
}
