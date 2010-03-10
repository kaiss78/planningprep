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
using App.Models.Users;
using System.Text;
using App.Core.Logging;
using App.Core.Mail;

public partial class Pages_Public_Register : System.Web.UI.Page
{
    public static Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Register with PlanningPrep.com");
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
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
            SaveRegistrationInfo();

            Response.Redirect(AppConstants.Pages.JOIN_OUTCOME);
            return;
        }
    }

    private void SaveRegistrationInfo()
    {
        App.Domain.Users.UserManager manager = new App.Domain.Users.UserManager();

        ///Populate the Object
        PlanningPrepUser user = new PlanningPrepUser();
        user.Username = txtUserName.Text.Trim();
        user.FirstName = txtFirstName.Text.Trim();
        user.LastName = txtLastName.Text.Trim();
        user.Author_email = txtEmail.Text.Trim();
        user.City = txtCity.Text.Trim();
        user.State = txtState.Text.Trim();
        user.ZIP = txtZip.Text.Trim();
        user.Employer = txtEmployer.Text.Trim();
        user.Address = txtAddress.Text.Trim();
        user.Title = txtTitle.Text.Trim();
        user.Password = txtPassword.Text;
        user.HowHear = ddlHowHear.SelectedValue;

        user.Active = false;
        user.Join_date = DateTime.Now;
        user.Mode = "Filtered";
        user.Show_email = false;
        user.Status = 1;
        user.User_code = GenerateUserCode(user.Username, user.Password);
        
        ///Save the Object
        manager.SaveOrUpdate(user);

        SendEmailNotification(user);        
    }
    
    /// <summary>
    /// Generates a User Code
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    protected string GenerateUserCode(string userName, string password)
    {
        /// Logic found in the old ASP Codebase
        /// strUserCode = strUsername & (9797299628 * CInt((RND * 32000) + 100)) & Left(strPassword,1) & Right(strPassword,1)                
        double randomNumber = 9797299628 * (random.Next(3200) + 100);
        return String.Format("{0}{1}{2}", userName.Substring(0, 1), randomNumber, password.Substring(password.Length - 1));
    }

    private bool IsEmailExists(string email)
    {
        App.Domain.Users.UserManager manager = new App.Domain.Users.UserManager();
        PlanningPrepUser user = manager.GetUserByEmail(email);
        return user == null ? false : true;
    }

    protected bool IsUserNameExists(string userName)
    {
        App.Domain.Users.UserManager manager = new App.Domain.Users.UserManager();
        PlanningPrepUser user = manager.GetUserByUserName(userName);
        return user == null ? false : true;
    }
    protected void SendEmailNotification(PlanningPrepUser user)
    {
        String messageBody = AppUtil.ReadEmailTemplate(AppConstants.EmailTemplate.GENERAL_EMAIL_TEMPLATE);
        StringBuilder sb = new StringBuilder();
 
        sb.AppendFormat(@"<b>Your registration to Planning Prep was successful.</b>  
                If you have paid through Paypal and allowed Paypal to redirect you back to our site, your account may be active. 
                If you have not paid for your account, your account will not be activated until receipt of payment.  For payment instructions please visit <a href=""http://www.planningprep.com/joinoutcome.asp"">http://www.planningprep.com/planning/joinoutcome.asp</a></p>
                <br/><br/>Accounts not instantly activated through Paypal are activated within 1-2 business days.  Once it is activated, you can login in using the following information: <br/><br/>
                Username: {0}<br/>Password: {1}<br/><br/>
                Please remember you cannot share this account.  Please make a record of this information for future use."
                , user.Username, user.Password); 
                                                                                        ;

        //If strReferredBy<>"" Then
        //    strBody=strBody + chr(13) & chr(13) & "Your friend, " & strReferredBy & " may be eligible for a $15 bonus provided they meet the requirements of our Refer-A-Friend Bonus Terms of Agreement." 
        //End If
        
        String toEmail = user.Author_email;
        String toName = String.Format("{0} {1}", user.FirstName, user.LastName);
        //String senderName = "Planning Prep Memberships";
        String sender = ConfigReader.AdminEmail;
        String subject = "Your Planning Prep Membership";
        messageBody = messageBody.Replace(AppConstants.ETConstants.MESSAGE, sb.ToString());
        try
        {
            MailManager.SendMail(toEmail, String.Empty, String.Empty, sender, subject, messageBody);
        }
        catch //(Exception ex)
        {
            //App.Core.Logging.AppLogger.HandleException(ex);
        }
    }    
}
