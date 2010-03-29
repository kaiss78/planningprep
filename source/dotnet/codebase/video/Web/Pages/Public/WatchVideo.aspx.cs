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
using App.Util;

public partial class WatchVideo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Medstudy - Watch video";
        int ItemNumber = AppUtil.GetRequestParamValueInInt(AppConstants.UrlParams.ITEM_NUMBER);
        watchVideo.ItemNumber = ItemNumber;
    }
}
