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

public partial class Pages_Public_Alert : System.Web.UI.Page
{
    protected String _RemoteIP;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Security Alert");
        if (!IsPostBack)
        {
            _RemoteIP = Request.ServerVariables["REMOTE_ADDR"];
            if (SessionCache.FailedLoginAttemptCount >= 5)
            {
                SendASecurityAlertToSiteAdmin();
            }
        }
    }
    protected void SendASecurityAlertToSiteAdmin()
    {
        String templateText = AppUtil.ReadEmailTemplate(AppConstants.EmailTemplate.GENERAL_EMAIL_TEMPLATE);        
        String messageBody = String.Format(@"SECURITY ALERT - MULTIPLE LOGIN ATTEMPTS FROM 
                            <b>{0}</b><br/><br/>The username last attempted was <b>{1}</b>"
                            , _RemoteIP, SessionCache.AttemptedUserName);

        templateText = templateText.Replace(AppConstants.ETConstants.MESSAGE, messageBody);            
        String subject = "Security Alert";
        //strName="Planning Prep"
        String toEmail = ConfigReader.AdminEmail; //"planningprep@gmail.com"
        try
        {
            App.Core.Mail.MailManager.SendMail(toEmail, String.Empty, String.Empty, toEmail, subject, templateText);
        }
        catch { }
    }
}
