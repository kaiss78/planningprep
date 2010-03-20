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
using System.Collections.Generic;
using App.Domain.Users;
using App.Models.Users;
using System.Web.Services;
using System.Text;
using App.Core.Mail;

public partial class Pages_Admin_SendEmail : BasePage
{
    protected bool _SendEmailToAll = false;
    private List<int> _SelectedUserIDs;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Send Email to Users");
        String userIDs = Request[AppConstants.QueryString.ID];
        if (String.Compare(userIDs, "All", false) == 0)        
            _SendEmailToAll = true;        

        if (!IsPostBack)
        {
            BindUserInfo();            
            BindSelectedUsersInfo(userIDs);
            //btnSendMessage.Attributes["onclick"] = String.Format("{0}; SendMessage();return false;", btnSendMessage.Attributes["onclick"]);
        }
    }

    private void BindSelectedUsersInfo(String userIDs)
    {
        _SelectedUserIDs = GetSeletedUsersIDList(userIDs);
        UserManager manager = new UserManager();
        IList<PlanningPrepUser> allUsers = manager.GetList();
        if (_SendEmailToAll)
            SessionCache.SelectedUsersForEmail = allUsers;
        else
        {
            ///Select the Selected Users from All Users Collection
            if (allUsers != null && allUsers.Count > 0)
            {
                IList<PlanningPrepUser> users = (from P in allUsers
                                                 where _SelectedUserIDs.Contains(P.Author_ID)
                                                 select P).ToList();

                SessionCache.SelectedUsersForEmail = users;

                if (users != null && users.Count > 0)
                {
                    StringBuilder sb = new StringBuilder(10);
                    sb.Append("Your email will be sent to the following selected members:<br />");
                    sb.Append("<ul>");
                    foreach (PlanningPrepUser user in users)
                    {
                        sb.AppendFormat("<li>{0}</li>", AppUtil.Encode(user.Username));
                    }
                    sb.Append("</ul>");
                    divUserInfo.InnerHtml = sb.ToString();
                }
                else
                {
                    divUserInfo.InnerHtml = "Sorry! No user was found in the system to send this email.";
                    divContainer.Visible = false;
                }
            }
            else
            {
                divUserInfo.InnerHtml = "Sorry! No user was found in the system to send this email.";
                divContainer.Visible = false;
            }
        }
    }

    private List<int> GetSeletedUsersIDList(string userIDs)
    {
        List<int> selectedUserIDs = new List<int>();
        String[] ids = userIDs.Split(',');
        if (ids != null && ids.Length > 0)
        {
            foreach (String sID in ids)
            {
                int id = 0;
                int.TryParse(sID, out id);
                if (id > 0)
                    selectedUserIDs.Add(id);
            }
        }
        return selectedUserIDs;
    }

    protected void BindUserInfo()
    {
        if (SessionCache.CurrentUser != null)
        {
            lblName.Text = String.Format("{0} {1} ({2})", AppUtil.Encode(SessionCache.CurrentUser.FirstName)
                    , AppUtil.Encode(SessionCache.CurrentUser.LastName)
                    , AppUtil.Encode(SessionCache.CurrentUser.Username));            

            lblEmail.Text = AppUtil.Encode(SessionCache.CurrentUser.Author_email);            
        }
    }

    [WebMethod(EnableSession=true)]
    public static int SendMessage(AdminMessage message)
    {
        if (message == null || String.IsNullOrEmpty(message.Subject) || String.IsNullOrEmpty(message.MessagBody))
            return -1;
        else
        {
            PrepareAndSendEmail(message);
        }        
        return 1;
    }
    /// <summary>
    /// Prepares the Email and Sends to the Corresponding User
    /// </summary>
    /// <param name="message"></param>
    public static void PrepareAndSendEmail(AdminMessage message)
    {
        String template = AppUtil.ReadEmailTemplate(AppConstants.EmailTemplate.GENERAL_EMAIL_TEMPLATE);
        if (template.Length > 0)
        {
            message.FromEmail = String.Format("{0} {1}<{2}>", AppUtil.Encode(SessionCache.CurrentUser.FirstName), AppUtil.Encode(SessionCache.CurrentUser.LastName), SessionCache.CurrentUser.Author_email);
            message.Subject = AppUtil.Encode(message.Subject);
            message.MessagBody = AppUtil.FormatText(message.MessagBody);
            foreach (PlanningPrepUser user in SessionCache.SelectedUsersForEmail)
            {
                String body = String.Format("Dear {0}, <br/><br/>{1}", AppUtil.Encode(user.Username), message.MessagBody);
                StringBuilder orgMessage = new StringBuilder(template);
                orgMessage.Replace(AppConstants.ETConstants.MESSAGE, body);
                try
                {
                    MailManager.SendMail(user.Author_email, String.Empty, String.Empty, message.FromEmail, message.Subject, orgMessage.ToString());
                }
                catch { }
            }
        }
    }
}
