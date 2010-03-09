#region References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data;


#endregion

#region Class

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    private bool terminateEvents = false;

    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
        WebUtil.LoginUser();        
    }

    #region Page load event
    /// <summary>
    /// Handles page load event
    /// </summary>
    /// <param name="e"></param>
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }
    #endregion

    #region Signout user
    /// <summary>
    /// Signouts the user.
    /// </summary>
    protected void SignoutUser()
    {
        WebUtil.SignoutUser();
    }
    #endregion
   
}

#endregion