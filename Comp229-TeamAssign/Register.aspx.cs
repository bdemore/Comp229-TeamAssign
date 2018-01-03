using Comp229_TeamAssign.Controllers;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamAssign
{
    public partial class Register : System.Web.UI.Page
    {
        protected string message = "";

        // The User Controller.
        private IUserController userController = UserController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Session["LoggedUser"] = userController.Register("bruno@demore.com", "Teste1234", "Bruno", "Demore");

            if (null == Session["LoggedUser"])
            {
                // Show error
            }
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

        protected void RegisterButton_Click1(object sender, EventArgs e)
        {
            Session["LoggedUser"] = userController.Register(FirstNameTextBox.Text, PasswordTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text);

            if (null == Session["LoggedUser"])
            {
                ShowErrorMessage("User already registered.");
            }

            Response.Redirect("~/");
        }

        /// <summary>
        /// Shows to the user any unexpecte error that may occur during the database communication.
        /// </summary>
        /// <param name="message">The error message to be shown.</param>
        private void ShowErrorMessage(string message)
        {
            this.message = string.Format("<hr/><b>{0}</b><hr/>", message);
            ErrorPanel.CssClass = "register-error-message-hidden";
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ClearPageTextBoxes(this);
        }
    }
}