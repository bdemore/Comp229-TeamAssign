using Comp229_TeamAssign.Controllers;
using Comp229_TeamAssign.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamAssign
{
    public partial class BookDetail : System.Web.UI.Page
    {
        // The book controller to be used.
        private IBookController bookController = BookController.GetInstance();
        private IBookRentalController bookRentalController = BookRentalController.GetInstance();

        // The error message.
        protected string message = "";

        protected Book book;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                book = bookController.RetrieveBookDetails(Request.QueryString["isbn"], Session["BookList"] as List<Book>);       
            }

            //TODO
            //if (null == Session["BookList"])
            //{
            //    Response.Redirect("~/");
            //}
        }

        protected void ReserveButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            User user = Session["LoggedUser"] as User;
            List<Book> books = Session["BookList"] as List<Book>;
            BookRental bookRental = bookRentalController.ReserveBook(user, books.Find(tBook => tBook.PrimaryKey.Key == decimal.Parse(button.CommandArgument)));

            if (null == bookRental)
            {
                ShowErrorMessage(string.Format("{0}, you have a pending rental. Please, return the book(s) in your possession before renting again!", user.FirstName));
            }
            else
            {
                Session["BookRental"] = bookRental;
                Response.Redirect("~/ReserveDetails");
            }
        }

        ///// <summary>
        ///// Shows to the user any unexpecte error that may occur during the database communication.
        ///// </summary>
        ///// <param name="message">The error message to be shown.</param>
        private void ShowErrorMessage(string message)
        {
            this.message = string.Format("<hr/><b>{0}</b><hr/>", message);
            ErrorPanel.CssClass = "register-error-message";
        }
    }
}