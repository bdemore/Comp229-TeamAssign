﻿using Comp229_TeamAssign.Controllers;
using System;
using System.Web.UI;

namespace Comp229_TeamAssign
{
    public partial class _Default : Page
    {
        // The book controller to be used.
        private IBookController bookController = BookController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BookRepeater.DataSource = bookController.RetrieveAllBooks();
                BookRepeater.DataBind();
            }
        }
    }
}