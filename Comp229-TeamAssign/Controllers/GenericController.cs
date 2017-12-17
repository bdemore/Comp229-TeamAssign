using Comp229_TeamAssign.Patterns;

namespace Comp229_TeamAssign.Controllers
{
    public abstract class GenericController<C> : Singleton<C>
        where C : GenericController<C>
    {
    }
}