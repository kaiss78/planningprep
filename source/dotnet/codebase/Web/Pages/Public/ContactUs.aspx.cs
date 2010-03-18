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
using System.Text;
using App.Core.Mail;

public partial class Pages_Public_ContactUs : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Contact Us");
        if (!IsPostBack)
        {
            BindUserInfo();
        }
    }

    protected void BindUserInfo()
    {
        if (SessionCache.CurrentUser != null)
        {
            lblName.Text = String.Format("{0} {1} ({2})", AppUtil.Encode(SessionCache.CurrentUser.FirstName)
                    , AppUtil.Encode(SessionCache.CurrentUser.LastName)
                    , AppUtil.Encode(SessionCache.CurrentUser.Username));            
            lblName.Visible = true;
            spnName.Visible = false;
            txtName.Visible = false;
            rfvName.EnableClientScript = false;
            rfvName.Enabled = false;

            lblEmail.Text = AppUtil.Encode(SessionCache.CurrentUser.Author_email);
            spnEmail.Visible = false;
            lblEmail.Visible = true;
            txtEmail.Visible = false;
            rfvEmail.EnableClientScript = false;
            rfvEmail.Enabled = false;
            revEmail.EnableClientScript = false;
            revEmail.Enabled = false;

            divPrivateMessage.Visible = true;
            divPublicMessage.Visible = false;
            divPrivateAddress.Visible = true;
            divPublicAddress.Visible = false;
        }
    }
    protected void btnSendMessage_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            PrepareAndSendEmail();
            Response.Redirect(String.Format("{0}?{1}=1", AppConstants.Pages.SHOW_MESSAGE, AppConstants.QueryString.ID), false);
            return;
        }
    }

    private void PrepareAndSendEmail()
    {
        StringBuilder template = new StringBuilder(AppUtil.ReadEmailTemplate(AppConstants.EmailTemplate.GENERAL_EMAIL_TEMPLATE));
        if (template.Length > 0)
        {
            String senderName = SessionCache.CurrentUser == null ? 
                        String.Format("{0}", AppUtil.Encode(txtName.Text.Trim())) 
                        : String.Format("{0} {1} ({2})", AppUtil.Encode(SessionCache.CurrentUser.FirstName), AppUtil.Encode(SessionCache.CurrentUser.LastName), AppUtil.Encode(SessionCache.CurrentUser.Username));

            String toEmail = SessionCache.CurrentUser == null ? 
                        String.Format("{0} <{1}>", senderName, txtEmail.Text.Trim()) 
                        : String.Format("{0} <{1}>", senderName, SessionCache.CurrentUser.Author_email);
            String fromEmail = ConfigReader.SupportEmail;
            String subject = AppUtil.Encode(txtSubject.Text.Trim());
            StringBuilder body = new StringBuilder(AppUtil.FormatText(txtComment.Text.Trim()));
            body.Append("<br /><br />");
            body.AppendFormat("<b>Sent By:</b> {0} <br />", senderName);
            body.AppendFormat("<b>From IP:</b> {0} <br />", AppUtil.GetRemoteIPAddress());

            template.Replace(AppConstants.ETConstants.MESSAGE, body.ToString());

            try
            {
                MailManager.SendMail(toEmail, String.Empty, String.Empty, fromEmail, subject, template.ToString());
            }
            catch { }
        }
    }
}
