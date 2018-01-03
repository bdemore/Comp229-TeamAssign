using Comp229_TeamAssign.Database.Models;

namespace Comp229_TeamAssign.Controllers
{
    interface IBookRentalController
    {
        /// <summary>
        /// Performs the rent of one book for the given user.
        /// </summary>
        /// <param name="user">The user that is renting the book</param>
        /// <param name="book">The book rented</param>
        /// <returns>The book rental information if successful. null otherwise.</returns>
        BookRental ReserveBook(User user, Book book);
    }
}
