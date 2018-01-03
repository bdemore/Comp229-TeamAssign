using System.Data.Common;
using Comp229_TeamAssign.Database.Models;
using Comp229_TeamAssign.Database.Models.PrimaryKeys;

namespace Comp229_TeamAssign.Database.DAOs
{
    /// <summary>
    /// Class to manage data access to the TBUB_USERS table.
    /// </summary>
    public class BookRentalDAO : GenericDAO<DecimalPrimaryKey, BookRental, BookRentalDAO>, IBookRentalDAO
    {
        /// <summary>
        /// Default Constructor used by Singleton.
        /// </summary>
        private BookRentalDAO()
        {
        }

        /// <see cref="GenericDAO{PK, M}"/>
        protected override string BuildFindAllOracleQueryString()
        {
            throw new System.NotImplementedException();
        }

        /// <see cref="GenericDAO{PK, M}"/>
        protected override string BuildFindAllSqlServerQueryString()
        {
            throw new System.NotImplementedException();
        }

        /// <see cref="GenericDAO{PK, M}"/>
        protected override BookRental CreateObjectFromDataReader(DbDataReader dataReader)
        {
            throw new System.NotImplementedException();
        }
    }
}