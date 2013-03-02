
namespace Gordias.Library.Headquarters
{
    using Gordias.Library.Interfaces;
    using System;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class PropertyAttribute : System.Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="PropertyType"></typeparam>
        /// <param name="target"></param>
        public static void Construction<PropertyType>(ITacticsProperty<PropertyType> target)
        {
            var accessers = target.Propertys;
            Type targetType = target.GetType();
            MethodInfo[] methods = targetType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                if (method.IsDefined(typeof(PropertyAttribute), false))
                {
                    var name = method.Name;

                    Type commandsType = accessers.GetType();
                    PropertyInfo propertys = commandsType.GetProperty(name);
                    MethodInfo commandMethod = method;
                    /*
                    propertys.SetValue(
                        accessers,
                        commandMethod.Invoke(target, null),
                        null);*/
                }
            }
        }
    }
}
