using Comp229_TeamAssign.Controllers;
using Comp229_TeamAssign.Database.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Comp229_TeamAssign
{
    public partial class _Default : Page
    {
        // The book controller to be used.
        private IBookController bookController = BookController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Book> books = bookController.RetrieveAllBooks();
        }
    }
}