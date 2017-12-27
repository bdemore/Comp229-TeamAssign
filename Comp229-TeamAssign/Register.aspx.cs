using Comp229_TeamAssign.Controllers;
using System;

namespace Comp229_TeamAssign
{
    public partial class Register : System.Web.UI.Page
    {
        // The User Controller.
        private IUserController userController = UserController.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null == Session["LoggedUser"])
            {
                Session["LoggedUser"] = userController.Register("bruno@demore.com", "Teste1234", "Bruno", "Demore");
            }
        }
    }
}