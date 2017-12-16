using System.Collections.Generic;
using Comp229_TeamAssign.Database.Models;
using Comp229_TeamAssign.Database.Models.PrimaryKeys;

namespace Comp229_TeamAssign.Database.DAOs
{
    /// <summary>
    /// Class that will be implemented by all the DAO classes.
    /// </summary>
    /// <typeparam name="PK">The Model's Primary Key class</typeparam>
    /// <typeparam name="M">The Model class</typeparam>
    public abstract class GenericDAO<PK, M> : IGenericDAO<PK, M>
        where PK : GenericPrimaryKey, new()
        where M : GenericModel<PK>, new()
    {
        /// <see cref="IGenericDAO{PK, M}"/>
        public abstract List<M> FindAll();

        /// <see cref="IGenericDAO{PK, M}"/>
        public abstract List<M> FindPaged(QueryPage queryPage);
    }
}