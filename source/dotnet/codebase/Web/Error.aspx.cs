﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Member_Error : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Error");

        int errorCode = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.ERROR_CODE);
        if(errorCode == 1)
        {
            lblMessage.Text = "You are not authorized to access this exam.";
        }
        else if(errorCode == 2)
        {
            lblMessage.Text = "You cannot start two concurrent exams.";
        }
        else if (errorCode == 3)
        {
            lblMessage.Text = "Requested item not found.";
        }
    }
}
