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
using App.Domain.Questions;
using App.Models.Questions;
using System.Collections.Generic;

public partial class Pages_Member_QuestionDetails : BasePage
{
    int QuestionID;
    int ShowRating;
    int ShowNextQuestion;
    int Correct;
    int Rated;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!LoadParams())
        {
            Response.Redirect("~/Error.aspx?ErrorCode=3");
            return;
        }

        questionDetails.QuestionID = QuestionID;
    }

    private bool LoadParams()
    {
        QuestionID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.QUESTION_ID);
        ShowRating = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.SHOW_RATING);
        ShowNextQuestion = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.SHOW_NEXT_QUESTION);
        Correct = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.CORRECT);
        Rated = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.QIESTION_RATED);
        
        questionDetails.ShowRating = ShowRating == 1? true : false;
        questionDetails.ShowNextQuestion = ShowNextQuestion == 1 ? true : false;
        questionDetails.Correct = Correct == 1 ? true : false;
        questionDetails.Rated = Rated == 1 ? true : false;

        if (QuestionID == 0)
        {
            return false;
        }
        return true;
    }

}
