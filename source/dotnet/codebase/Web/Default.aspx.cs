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
using App.Models.Users;

public partial class Default : BasePage
{
    protected int _NumberOfQuestions;
    protected String _LastQuestionDate;
    protected App.Models.Questions.Questions _QuestionOfTheWeek;
    private const String CORRECT_ANSWER = "CorrectAnswer";
    private const String QUESTION_OF_THE_WEEK_USERID = "UserID";


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Home");
        if(!IsPostBack)
            SetInitialValues();

        //ValidateFaceBookUser();
        //String value = AppUtil.GetCookie("TestingCookie");
        //if(String.IsNullOrEmpty(value))
        //    AppUtil.SetCookie("TestingCookie", "Tutul");
    }

    //private void ValidateFaceBookUser()
    //{
    //    FBConnectAuth.FBConnectAuthentication auth = new FBConnectAuth.FBConnectAuthentication(ConfigReader.FaceBookAPIKey, ConfigReader.FaceBookSecretPhrase);
        
    //    if (auth.Validate() != FBConnectAuth.ValidationState.Valid)
    //    {
    //        // The request does not contain the details of a valid Facebook connect session - you'll probably want to throw an error here.
    //    }
    //    else
    //    {
    //        FBConnectAuth.FBConnectSession faceBookSession = auth.GetSession();
    //        String userId = faceBookSession.UserID;
    //        String sessionKey = faceBookSession.SessionKey;
    //    }
    //}

    private void SetInitialValues()
    {
        App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
        _NumberOfQuestions = manager.GetPagedList(1, int.MaxValue).Count;
        _LastQuestionDate = manager.LastQuestionDate().ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY_WITH_TIME);

        _QuestionOfTheWeek = manager.Get(ConfigReader.QuestionOfTheWeekID);
        if (_QuestionOfTheWeek != null)
        {
            ViewState[QUESTION_OF_THE_WEEK_USERID] = 2;
            ViewState[CORRECT_ANSWER] = _QuestionOfTheWeek.CorrectAnswer;
        }
    }
    /// <summary>
    /// Gets the Next Exam Window Message
    /// </summary>
    /// <returns></returns>
    protected String GetNextExamWindow()
    {
        ///Ekhane Ekta Udvot Logic Implement Kortechi
        String message = String.Empty;
        String month = "May";
        if (DateTime.Today.Month > 5 )
            month = "November";

        int year = DateTime.Today.Year;
        DateTime examDate = new DateTime(year, 5, 10);
        DateTime examDate2 = new DateTime(year, 5, 24);
        double dateDiff = examDate.Subtract(DateTime.Today).TotalDays;

        switch(month)
        {
            case "May":               
                if(DateTime.Today < examDate2) 
                {
                    if(dateDiff > 1)
                        message = String.Format("{0} days until the May Exam Window", dateDiff);
                    if( dateDiff == 1 )
				        message = "Only 1 day until the May Exam Window. Good Luck!";
                    if( dateDiff < 1 )
		    		    message = "The May Exam Window is here, Good Luck!";
                }
                else
                    message = "The May Exam Window has Closed. Register now for November";
                break;
            case "November":
                examDate = new DateTime(year, 11, 8);
                examDate2 = new DateTime(year, 11, 22);
                dateDiff = examDate.Subtract(DateTime.Today).TotalDays;

                if(DateTime.Today < examDate2) 
                {
                    if(dateDiff > 1)
                        message = String.Format("{0} days until the November Exam Window", dateDiff);
                    if( dateDiff == 1 )
				        message = "Only 1 day until the November Exam Window. Good Luck!";
                    if( dateDiff < 1 )
		    		    message = "The November Exam Window is here, Good Luck!";
                }
                else
                    message = "The November Exam Window has Closed. Register now for May";
                
                break;

            default:
                break;
        }
        return message;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String givenAnswer = Request.Form["Answer"];
            App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
            manager.SaveQuestionOfTheWeekAnswer(ConfigReader.QuestionOfTheWeekID, 2, givenAnswer);
            String url = String.Format("{0}?{1}={2}&{3}={4}", AppConstants.Pages.ANSWER_OF_THE_WEEK_MESSAGE, AppConstants.QueryString.QUESTION_ID, ConfigReader.QuestionOfTheWeekID, AppConstants.QueryString.ANSWER, givenAnswer);
            Response.Redirect(url, false);
            return;
        }
    }
}
