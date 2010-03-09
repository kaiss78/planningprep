using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AddNewUser : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            ListBox lb = CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("AvailableRoles") as ListBox;// wzCreateuser.TemplateControl.FindControl("AvailableRoles") as ListBox;
            lb.SelectedIndex = 0;
            string[] roles = Roles.GetAllRoles();
            lb.DataSource = roles;
            lb.DataBind();
        }
    }

    protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
    {
        if (Page.IsValid)
        {

        }

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        ListBox lb = CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("AvailableRoles") as ListBox;// wzCreateuser.TemplateControl.FindControl("AvailableRoles") as ListBox;
        for (int i = 0; i < lb.Items.Count; i++)
        {
            if (lb.Items[i].Selected == true)
                Roles.AddUserToRole(CreateUserWizard1.UserName, lb.Items[i].Value);
        }        
    }
    protected void CreateUserWizard1_CreateUserError(object sender, CreateUserErrorEventArgs e)
    {
        //e.CreateUserError == MembershipCreateStatus.
    }
}
