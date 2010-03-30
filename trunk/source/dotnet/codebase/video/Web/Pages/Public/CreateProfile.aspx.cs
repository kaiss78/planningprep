using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Util;
using App.Domain;
using App.Data;
using System.Text;


public partial class Pages_Public_CreateProfile : System.Web.UI.Page
{
    protected UserManager _UserManager = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Create New Profile");
        _UserManager = new UserManager();
        if (!IsPostBack)
        {
            BindYears();
        }
    }

    private void BindYears()
    {       
        for (int i = 0; i >= -50; i--)
        {
            int year = DateTime.Now.AddYears(i).Year;
            ddlResidency.Items.Add(new ListItem(year.ToString(), year.ToString()));
        }
    }
    #region Methods
    protected bool IsEmailExists(String email)
    {
        if (_UserManager.GetByUserByEmail(email) == null)
            return false;

        return true;
    }

    protected bool HasSerialKeyTaken(String serialKey)
    {
        if (_UserManager.GetByUserBySerialKey(serialKey) == null)
            return false;
        return true;
    }
    protected bool IsSeriralKeyExists(String key)
    {
        SerialKeyManager manager = new SerialKeyManager();
        return manager.IsKeyExists(key);
    }
    private void CreateNewProfile()
    {
        SiteUser user = new SiteUser();
        user.SerialKey = txtSerialKey.Text.Trim();
        user.FirstName = txtFirstName.Text.Trim();
        user.MiddleName = txtMiddleName.Text.Trim();       
        user.LastName = txtLastName.Text.Trim();
        user.Email = txtEmail.Text.Trim();
        user.IsResident = String.Compare(ddlIsResident.SelectedValue, "1", false) == 0 ? true : false;
        if (user.IsResident)
            user.ResidencyYear = Convert.ToInt32(ddlResidency.SelectedValue);

        user.IsActive = false;
        user.ActivationKey = Guid.NewGuid().ToString();

        _UserManager.Save(user);
        //AppUtil.ShowMessage(divMessageBox, "Congratulations"
        SendEmailNotification(user);
        ShowConfirmationMessage();
    }

    private void ShowConfirmationMessage()
    {
        pnlDetails.Visible = false;
        pnlConfirmation.Visible = true;
        lblSuccessMessage.Text = String.Format(lblSuccessMessage.Text, txtEmail.Text.Trim());
    }

    protected void SendEmailNotification(SiteUser user)
    {
        StringBuilder template = new StringBuilder(AppUtil.ReadEmailTemplate(AppConstants.EmailTemplate.GENERAL_TEMPLATE));
        if (template.Length > 0)
        {
            String fromEmail = ConfigReader.SupportEmail;
            String subject = "Activate your account.";
            StringBuilder sb = new StringBuilder(10);
            sb.AppendFormat("Dear {0} {1} {2}<br/>", AppUtil.Encode(user.FirstName), AppUtil.Encode(user.MiddleName), AppUtil.Encode(user.LastName));
            sb.Append("You have successfully created your profile. Please click on the following link to activate your account.<br/><br/>");
            String Url = String.Format("{0}{1}?{2}={3}", AppUtil.GetDomainAddress(), AppConstants.Pages.ACTIVATE_ACCOUNT, AppConstants.UrlParams.KEY, user.ActivationKey);
            sb.AppendFormat("<a href='{0}'>{0}</a>", Url);
            sb.Append("<br/><br/>");
            sb.Append("Thanks");

            template.Replace(AppConstants.EmailTemplate.CustomTag.MESSAGE, sb.ToString());
            
            try
            {
                MailHelper.SendMail(user.Email, String.Empty, String.Empty, fromEmail, subject, template.ToString());
            }
            catch{}
        }
    }
    #endregion

    #region Events
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (!IsSeriralKeyExists(txtSerialKey.Text.Trim()))
            {
                AppUtil.ShowMessage(divMessageBox, "Sorry! the Serial Key does not exist.", true);
                return;
            }
            if (HasSerialKeyTaken(txtSerialKey.Text.Trim()))
            {
                AppUtil.ShowMessage(divMessageBox, "Sorry! the Serial Key is already taken. Please try with a different Serial Key.", true);
                return;
            }
            if (IsEmailExists(txtEmail.Text.Trim()))
            {
                AppUtil.ShowMessage(divMessageBox, "Sorry! the email is already taken. Please try with a different email.", true);
                return;
            }            
            CreateNewProfile();
        }
    }
    #endregion
}
