using System;
using System.Reflection;

namespace Comp229_TeamAssign.Patterns
{
    /// <summary>
    /// Abstract class implementing the Singleton design pattern.
    /// </summary>
    /// <typeparam name="T">The class type that should be instantiated</typeparam>
    public abstract class Singleton<T>
    {
        protected static T INSTANCE = default(T);

        /// <summary>
        /// Gets the singleton instance. If not yet created, create the instance dynamically and return it. Otherwise just return the existing instance.
        /// </summary>
        /// <returns>The singleton instance.</returns>
        public static T GetInstance()
        {
            // Using reflection to instantiate the child singleton class.
            if (null == INSTANCE)
            {
                Type type = typeof(T);
                ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                INSTANCE = (T) constructors[0].Invoke(new object[] { });
            }

            return INSTANCE;
        }
    }
}