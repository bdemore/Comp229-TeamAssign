using Comp229_TeamAssign.Database.Models;
using Comp229_TeamAssign.Database.Models.PrimaryKeys;

namespace Comp229_TeamAssign.Database.DAOs
{
    /// <summary>
    /// Interface containing all the methods to be implemented by the BookRentalDAO.
    /// </summary>
    interface IBookRentalDAO : IGenericDAO<DecimalPrimaryKey, BookRental>
    {
    }
}
