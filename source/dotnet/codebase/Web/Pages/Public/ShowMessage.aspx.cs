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

public partial class Pages_Public_ShowMessage : BasePage
{
    private bool _IsErrorMessage;
    private int _MessageID;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Message");
        if (String.Compare(Request[AppConstants.QueryString.MSG_TYPE], "Error", false) == 0)
            _IsErrorMessage = true;

        _MessageID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.ID);

        DisplayMessage();
    }

    private void DisplayMessage()
    {
        String message = String.Empty;
        if (_MessageID == 1)
        {
            if (SessionCache.CurrentUser == null)
                message = @"Your message was successfully delivered.  You will be contacted by
    	                    a member of planningprep.com.  Thank you for your message.  Please
        	                <a href='/Default.aspx'>click here</a> to return to the home page.";
            else
                message = String.Format(@"{0}, we received your message. Thank you for your correspondence.
                        We are continuing to improve our site, and feedback and comments from our members
                        is very important. We will reply to your message as soon as we can. <br />Thanks again.<br /><br />
                        Sincerely,<br />Planningprep.com.", SessionCache.CurrentUser.Username);

            AppUtil.ShowMessageBox(divMessage, message, _IsErrorMessage);
        }
    } 
}
