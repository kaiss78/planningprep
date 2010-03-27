using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Util;
using App.Domain;
using App.Data;


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

        _UserManager.Save(user);
        //AppUtil.ShowMessage(divMessageBox, "Congratulations"
        SendEmailNotification();
        ShowConfirmationMessage();
    }

    private void ShowConfirmationMessage()
    {
        throw new NotImplementedException();
    }

    private void SendEmailNotification()
    {
        pnlDetails.Visible = false;
        pnlConfirmation.Visible = true;
        lblSuccessMessage.Text = String.Format(lblSuccessMessage.Text, txtEmail.Text.Trim());
    }
    #endregion

    #region Events
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (IsEmailExists(txtEmail.Text.Trim()))
            {
                AppUtil.ShowMessage(divMessageBox, "Sorry! the email is already taken. Please try with a different email.", true);
                return;
            }
            if(HasSerialKeyTaken(txtSerialKey.Text.Trim()))
            {
                AppUtil.ShowMessage(divMessageBox, "Sorry! the Serial Key is already taken. Please try with a different Serial Key.", true);
                return;
            }
            CreateNewProfile();
        }
    }
    #endregion
}
