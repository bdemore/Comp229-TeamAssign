using Comp229_TeamAssign.Controllers;
using Comp229_TeamAssign.Database.Models;
using System;
using System.Collections.Generic;

namespace Comp229_TeamAssign
{
    public partial class UpdateBook : System.Web.UI.Page
    {
        protected string message = "";

        // The book controler
        private IBookController bookController = BookController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((null != Session["BookList"]) && (null != Request.QueryString["isbn"]))
                {
                    Book book = bookController.RetrieveBookDetails(Request.QueryString["isbn"], Session["BookList"] as List<Book>);

                    BookIsbnTextBox.Text = book.PrimaryKey.Key.ToString();
                    BookTitleTextBox.Text = book.Title;
                    BookDescriptionTextBox.Text = book.Description;
                    BookPublicatinDateTextBox.Text = book.PublicationDate.Value.ToString(@"yyyy-MM-dd");
                    BookQuantityAvailableTextBox.Text = book.QuantityAvailable.ToString();
                    BookEditionTextBox.Text = book.Edition.ToString();
                    BookAvailableDropDownList.SelectedValue = book.IsAvailable ? "1" : "0";
                    BookPagesTextBox.Text = book.Pages.ToString();
                    BookImageUrl01.Text = book.ImageUrl01;

                    if (!string.IsNullOrEmpty(book.ImageUrl02))
                    {
                        BookImageUrl02.Text = book.ImageUrl02;
                    }

                    if (!string.IsNullOrEmpty(book.ImageUrl03))
                    {
                        BookImageUrl03.Text = book.ImageUrl03;
                    }

                    if (!string.IsNullOrEmpty(book.ImageUrl04))
                    {
                        BookImageUrl04.Text = book.ImageUrl04;
                    }

                    if (!string.IsNullOrEmpty(book.ImageUrl05))
                    {
                        BookImageUrl05.Text = book.ImageUrl05;
                    }
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            bookController.UpdateBook(
                decimal.Parse(BookIsbnTextBox.Text),
                BookTitleTextBox.Text,
                BookDescriptionTextBox.Text,
                DateTime.ParseExact(BookPublicatinDateTextBox.Text, "yyyy-MM-dd", null),
                decimal.Parse(BookEditionTextBox.Text),
                BookAvailableDropDownList.SelectedValue == "0" ? false : true,
                decimal.Parse(BookQuantityAvailableTextBox.Text),
                decimal.Parse(BookPagesTextBox.Text),
                BookImageUrl01.Text,
                string.IsNullOrEmpty(BookImageUrl02.Text) ? null : BookImageUrl02.Text,
                string.IsNullOrEmpty(BookImageUrl03.Text) ? null : BookImageUrl03.Text,
                string.IsNullOrEmpty(BookImageUrl04.Text) ? null : BookImageUrl04.Text,
                string.IsNullOrEmpty(BookImageUrl05.Text) ? null : BookImageUrl05.Text
            );
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}