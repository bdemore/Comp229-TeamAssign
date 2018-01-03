using Comp229_TeamAssign.Controllers;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamAssign
{
    public partial class Login : System.Web.UI.Page
    {
        private IUserController userController = UserController.GetInstance();
        protected string message = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null == Session["LoggedUser"])
            {
                Session["LoggedUser"] = userController.Login("rjdsilv@gmail.com", "Teste1234");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Session["LoggedUser"] = userController.Login(EmailLoginTextBox.Text, PasswordLoginTextBox.Text);
            Response.Redirect("~/");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ClearPageTextBoxes(this);
        }

        private void ClearPageTextBoxes(Control control)
        {
            foreach (Control currControl in control.Controls)
            {
                if (currControl is TextBox)
                {
                    (currControl as TextBox).Text = "";
                }
                else
                {
                    ClearPageTextBoxes(currControl);
                }
            }
        }
    }
}