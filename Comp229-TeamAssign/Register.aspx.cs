using Comp229_TeamAssign.Controllers;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamAssign
{
    public partial class Register : System.Web.UI.Page
    {
        // The User Controller.
        private IUserController userController = UserController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LoggedUser"] = userController.Register("bruno@demore.com", "Teste1234", "Bruno", "Demore");
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
    }
}