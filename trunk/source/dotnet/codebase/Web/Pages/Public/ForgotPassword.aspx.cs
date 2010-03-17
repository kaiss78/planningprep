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
using System.Text;
using App.Core.Mail;

public partial class Pages_Public_ForgotPassword : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Lost Login Information");
        if (!IsPostBack)
        {
            txtEmail.Focus();
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SearchAndSendEmail();
        }
    }

    private void SearchAndSendEmail()
    {
        UserManager manager = new UserManager();
        PlanningPrepUser user = manager.GetUserByEmail(txtEmail.Text.Trim());
        if (user == null)
        {
            AppUtil.ShowMessageBox(divMessageBox, "We could not locate your email address in our database. Please <a href='ContactUs.aspx'>contact us</a> if you are having problems.", true);
            txtEmail.Text = String.Empty;
        }
        else
        {
            StringBuilder template = new StringBuilder(AppUtil.ReadEmailTemplate(AppConstants.EmailTemplate.GENERAL_EMAIL_TEMPLATE));
            StringBuilder body = new StringBuilder(10);
            String toEmail = String.Format("{0} {1} <{2}>", user.FirstName, user.LastName, user.Author_email);
            String fromEmail = ConfigReader.AdminEmail;
            String subject = "Login Information";
            body.AppendFormat("Your memberhsip information is as follows:");
            body.AppendFormat("<br/><br/>");
            body.AppendFormat("<b>Username:</b> {0}", user.Username);
            body.AppendFormat("<br/>");
            body.AppendFormat("<b>Password:</b> {0}", user.Password);
            body.AppendFormat("<br/><br/>");
            body.AppendFormat("Please remember this information.");
            body.AppendFormat("<br/>");
            body.AppendFormat("This username and password request was from the following IP Address: ");
            body.AppendFormat("<br/>");
            body.AppendFormat("{0}", AppUtil.GetRemoteIPAddress());

            template.Replace(AppConstants.ETConstants.MESSAGE, body.ToString());
            try
            {
                MailManager.SendMail(toEmail, String.Empty, String.Empty, fromEmail, subject, template.ToString());
            }
            catch { }

            AppUtil.ShowMessageBox(divMessageBox, "Your membership information has been sent to your email address.", false);
            pnlDetails.Visible = false;
            pnlMessage.Visible = false;
            //SendEmailNotification(user);
        }
    }
}
