using Comp229_TeamAssign.Controllers;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamAssign
{
    public partial class Login : System.Web.UI.Page
    {
        // The error message.
        protected string message = "";

        // The user controller.
        private IUserController userController = UserController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Captures the login button click and attempt to login the user on the system.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Session["LoggedUser"] = userController.Login(EmailLoginTextBox.Text, PasswordLoginTextBox.Text);

            if (null == Session["LoggedUser"])
            {
                ShowErrorMessage("Invalid credencials. Email or Password are incorrect.");
            }
            else
            {
                Response.Redirect("~/");
            }
        }

        /// <summary>
        /// Cancels the operation and redirects the user to the home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ClearPageTextBoxes(this);
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

        /// <summary>
        /// Clears all the text boxes for the given controls.
        /// </summary>
        /// <param name="control">The control to be cleaned</param>
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