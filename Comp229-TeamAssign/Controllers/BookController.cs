using Comp229_TeamAssign.Database.DAOs;
using Comp229_TeamAssign.Database.Models;
using System.Collections.Generic;

namespace Comp229_TeamAssign.Controllers
{
    /// <summary>
    /// Controller class that will have the necessary business logic to deal with Books.
    /// </summary>
    public class BookController : GenericController<BookController>, IBookController
    {
        // The book dao to be accessed.
        private IBookDAO bookDAO = BookDAO.GetInstance();

        private BookController()
        {
        }

        /// <see cref="IBookController"/>
        public List<Book> RetrieveAllBooks()
        {
            return bookDAO.FindAll();
        }
    }
}