using Comp229_TeamAssign.Controllers;
using Comp229_TeamAssign.Database.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamAssign
{
    public partial class _Default : Page
    {
        // The book controller to be used.
        private IBookController bookController = BookController.GetInstance();
        private IBookRentalController bookRentalController = BookRentalController.GetInstance();

        /// <summary>
        /// Loads the page containing all the selected books.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if ((null == Session["BookList"]) || ("true" == Request.QueryString["showAll"]))
                    {
                        Session["BookList"] = bookController.RetrieveAllBooks();
                    }

                    ShowBooks();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void ReserveButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            List<Book> books = Session["BookList"] as List<Book>;
            BookRental bookRental = bookRentalController.ReserveBook(Session["LoggedUser"] as User, books.Find(tBook => tBook.PrimaryKey.Key == decimal.Parse(button.CommandArgument)));
        }

        /// <summary>
        /// Shows the selected books on the screen.
        /// </summary>
        private void ShowBooks()
        {
            BookRepeater.DataSource = Session["BookList"];
            BookRepeater.DataBind();
        }
    }
}