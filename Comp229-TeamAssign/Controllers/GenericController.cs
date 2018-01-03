using Comp229_TeamAssign.Patterns;
using Comp229_TeamAssign.Utils;

namespace Comp229_TeamAssign.Controllers
{
    /// <summary>
    /// Generic class to be used by all the controller classes.
    /// </summary>
    /// <typeparam name="C"></typeparam>
    public abstract class GenericController<C> : Singleton<C>
        where C : GenericController<C>
    {
        // The parameter prefix.
        protected string paramPrefix = DatabaseUtils.IsOracle() ? "" : "@";
    }
}