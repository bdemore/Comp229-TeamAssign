using Comp229_TeamAssign.Database.DAOs;
using Comp229_TeamAssign.Database.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Comp229_TeamAssign
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IBookDAO bookDAO = BookDAO.GetInstance();
            List<Book> books = bookDAO.FindAll();
        }
    }
}