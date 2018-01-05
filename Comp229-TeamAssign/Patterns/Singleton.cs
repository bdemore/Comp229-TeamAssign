using Comp229_TeamAssign.Utils;

namespace Comp229_TeamAssign.Patterns
{
    /// <summary>
    /// Abstract class implementing the Singleton design pattern.
    /// </summary>
    /// <typeparam name="T">The class type that should be instantiated</typeparam>
    public abstract class Singleton<T>
    {
        protected static T INSTANCE = ReflectionUtils.ConstructDefaultNonPublic<T>();

        /// <summary>
        /// Gets the singleton instance. If not yet created, create the instance dynamically and return it. Otherwise just return the existing instance.
        /// </summary>
        /// <returns>The singleton instance.</returns>
        public static T GetInstance()
        {
            return INSTANCE;
        }
    }
}