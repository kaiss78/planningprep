﻿using System;
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
using App.Models.Questions;

public partial class Member_QuestionList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Question List");
        int viewAll = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.VIEW_ALL);
        if (viewAll == 1)
        {
            divViewAll.Visible = true;
        }
        else
        {
            divViewAll.Visible = false;
        }

        if (SessionCache.CurrentUser != null)
        {
            hlinkUserProfile.NavigateUrl = "UserProfile.aspx?UserID=" + SessionCache.CurrentUser.Author_ID;
        }
    }

}
