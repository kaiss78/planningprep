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
using App.Domain.Users;
using App.Models.Users;

public partial class UserControls_UserProfile : System.Web.UI.UserControl
{
    protected bool _IsEditMode = false;
    protected const String USER_ID = "UserID";

    public int UserID
    {
        get;
        set;
    }
    public bool IsEditMode
    {
        get { return _IsEditMode; }
        set { _IsEditMode = value; }
    }
    public bool ShowInfoText
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            if (IsEditMode)
            {
                LoadPorfileForEdit();
                ViewState[USER_ID] = this.UserID;
            }
            else
                LoadUserProfileInfo();
            
        }
    }    
    protected void LoadUserProfileInfo()
    {
        UserManager manager = new UserManager();
        PlanningPrepUser user = manager.Get(this.UserID);
        if (user == null)
        {
            ltrProfileHeading.Text = "Sorry! The requested user profile was not found.";
            pnlUserProfile.Visible = false;
        }
        else
        {
            ltrProfileHeading.Text = String.Format("Profile for {0} {1} ({2})", user.FirstName, user.LastName, user.Username);
            Page.Title = AppUtil.GetPageTitle(String.Format("Member Profile - {0}", ltrProfileHeading.Text));
            hplProfileEdit.NavigateUrl = AppConstants.Pages.EDIT_PROFILE;
            if (ShowInfoText)
            {
                divInfoText.Visible = true;
            }

            lblFirstName.Text = GetFormatedText(user.FirstName);
            lblLastName.Text = GetFormatedText(user.LastName);
            lblUserName.Text = GetFormatedText(user.Username);
            lblPassword.Text = "*******";
            lblAddress.Text = GetFormatedText(user.Address);
            lblEmail.Text = GetFormatedText(user.Author_email);
            lblPhoneNumber.Text = GetFormatedText(user.HomePhone);
            if (String.IsNullOrEmpty(user.Homepage))
                ltrHomePage.Text = "Not Specified";
            else
                ltrHomePage.Text = String.Format("<a href='{0}' target='_blank'>{1}</a>", AppUtil.GetCompleteUrl(user.Homepage), user.Homepage);

            lblQuestionMode.Text = GetFormatedText(user.Mode);
            lblCity.Text = GetFormatedText(user.City);
            lblState.Text = GetFormatedText(user.State);
            lblZip.Text = GetFormatedText(user.ZIP);
            lblDateJoined.Text = user.Join_date.ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY);
        }
    }
    private string GetFormatedText(String text)
    {
        if (String.IsNullOrEmpty(text))
            return "Not Specified";
        else
            return AppUtil.Encode(text);
    }
    private void LoadPorfileForEdit()
    {
        UserManager manager = new UserManager();
        PlanningPrepUser user = manager.Get(this.UserID);
        if (user != null)
        {
            ltrProfileHeading.Text = String.Format("Modify Profile for {0} {1} ({2})", user.FirstName, user.LastName, user.Username);
            Page.Title = AppUtil.GetPageTitle(ltrProfileHeading.Text);
            divInfoText.InnerHtml = "Use this form below to update data in our membership database. Make any changes below and press submit.";
            divInfoText.Visible = true;
            hplProfileEdit.Visible = false;

            txtFirstName.Text = user.FirstName.Trim();
            txtLastName.Text = user.LastName.Trim();
            lblUserNameEdit.Text = GetFormatedText(user.Username);
            txtUserPassword.Attributes["value"] = user.Password;

            txtAddress.Text = user.Address.Trim();
            txtEmail.Text = user.Author_email.Trim();
            txtPhoneNumber.Text = user.HomePhone.Trim();
            txtHomePage.Text = user.Homepage.Trim();
            txtCity.Text = user.City.Trim();
            txtState.Text = user.State.Trim();
            txtZip.Text = user.ZIP.Trim();
            lblDateJoinedEdit.Text = user.Join_date.ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY);
            if (!String.IsNullOrEmpty(user.Mode))
                ddlQuestionMode.SelectedValue = user.Mode;
        }
        else
        {
            ltrProfileHeading.Text = String.Format("Add a new user");
            Page.Title = AppUtil.GetPageTitle(ltrProfileHeading.Text);
            divInfoText.InnerHtml = "Use this form below to add a User in the membership database.";
            divInfoText.Visible = true;
            hplProfileEdit.Visible = false;

            txtUserName.Visible = true;
            rfvUserName.Visible = true;
            lblUserNameEdit.Visible = false;
            lblDateJoinedEdit.Visible = false;
            lblDateJoinedLabel.Visible = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (txtUserName.Visible)
            {
                if (IsUserNameExists(txtUserName.Text.Trim()))
                {
                    divErrorMessage.InnerHtml = String.Format("Sorry! The Username <b>{0}</b> has already been taken. Please choose another one.", txtUserName.Text);
                    divErrorMessage.Visible = true;
                    return;
                }
                if (IsEmailExists(txtEmail.Text))
                {
                    divErrorMessage.InnerHtml = String.Format("Sorry! The Email <b>{0}</b> has already been taken. Please choose another one.", txtEmail.Text);
                    divErrorMessage.Visible = true;
                    return;
                }
            }

            SaveUserInfo();
            Response.Redirect(AppConstants.Pages.MANAGE_USERS, false);
            return;
        }
    }

    protected bool IsUserNameExists(string userName)
    {
        App.Domain.Users.UserManager manager = new App.Domain.Users.UserManager();
        PlanningPrepUser user = manager.GetUserByUserName(userName);
        return user == null ? false : true;
    }

    private bool IsEmailExists(string email)
    {
        App.Domain.Users.UserManager manager = new App.Domain.Users.UserManager();
        PlanningPrepUser user = manager.GetUserByEmail(email);
        return user == null ? false : true;
    }

    protected void SaveUserInfo()
    {
        int userId = 0;
        int.TryParse(ViewState[USER_ID].ToString(), out userId);
        UserManager manager = new UserManager();
        PlanningPrepUser user = manager.Get(userId);
        if (user != null)
        {
            ///Populate the Object
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            //lblUserName.Text = GetFormatedText(user.Username);
            user.Password = txtUserPassword.Text;
            user.Address = txtAddress.Text;
            user.Author_email = txtEmail.Text;
            user.HomePhone = lblPhoneNumber.Text;
            user.Homepage = txtHomePage.Text;
            user.HomePhone = txtPhoneNumber.Text;
            user.City = txtCity.Text;
            user.State = txtState.Text;
            user.ZIP = txtZip.Text;
            //lblDateJoinedEdit.Text = user.Join_date.ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY);            
            user.Mode = ddlQuestionMode.SelectedValue;
            manager.SaveOrUpdate(user);
        }
    }
}
