using Comp229_TeamAssign.Database.Models;
using System.Collections.Generic;

namespace Comp229_TeamAssign.Controllers
{
    /// <summary>
    /// Interface containing all the methods that must be implemented by a BookController.
    /// </summary>
    interface IBookController
    {
        /// <summary>
        /// Method responsible for retrieving all the books from the databae.
        /// </summary>
        /// <returns>The list of all books contained on the database.</returns>
        List<Book> RetrieveAllBooks();
    }
}
