using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for AppConstants
/// </summary>
public class AppConstants
{
    public const string APPLICATION_ENGINE = "AppEngine";
    public const string CURRENT_USER = "CURRENT_USER";
    public const string EMPLOYEE_IMAGE_DIRECTORY = "~/EmployeeImages";
    public const string PRODUCT_IMAGE_DIRECTORY = "~/ProductImages";
    public const String ERROR_MESSAGE = @"Sorry!<br/>System encountered some problem while saving your comment. An administrator has been notified about the details of this problem. Please try after some time.";

    public class Pages
    {
        public const string EDIT_QUESTION = "/Pages/Admin/EditQuestion.aspx";
        public const string MANAGE_QUESTIONS = "/Pages/Admin/ManageQuestions.aspx";
        public const string QUESTION_DETAILS = "/Pages/Member/QuestionDetails.aspx";
        public const string EDIT_USERS = "/Pages/Admin/EditUser.aspx";
        public const string MANAGE_USERS = "/Pages/Admin/ManageUsers.aspx";
        public const string USER_DETAILS = "/Pages/Admin/UserDetails.aspx";
        public const string ANSWER_QUESTION = "/Pages/Member/AnswerQuestion.aspx";
        public const string EDIT_PROFILE = "/Pages/Member/EditProfile.aspx";
        public const string USER_PROFILE = "/Pages/Member/UserProfile.aspx";   
        public const string JOIN_OUTCOME = "/Pages/Public/JoinOutcome.aspx";
        public const string ANSWER_OF_THE_WEEK_MESSAGE = "/Pages/Public/AnswerOfTheWeekMessage.aspx";
        public const string VISIT_FRAME = "/Pages/Public/VisitFrame.aspx";
        public const string SHOW_CONTENT = "/Pages/Public/ShowContent.aspx";
        public const string TERMS_OF_USE = "/Pages/Public/TermsOfUse.aspx";
        public const string ALERT = "/Pages/Public/Alert.aspx";
        public const string QUESGION_LIST = "/Pages/Member/QuestionList.aspx";
        public const string QUESGION_SEARCH = "/Pages/Member/Questions.aspx";        
    }

    public class ValueOf
    {
        public const string CALENDAR_DATE_FORMAT = "dd/MM/yyyy";
        public const string DECIMAL_FORMAT = "{0:0,0.00}";
        public const string DECIMAL_FORMAT_CALCULATION = "{0:00.####}";
        public const string DATE_FROMAT_DISPLAY = "MMMM dd, yyyy";
        public const string DATE_FROMAT_DISPLAY_WITH_TIME = "dddd, MMMM dd, yyyy hh:mm:ss tt";
    }
    public class UserRoles
    {
        public const String ADMINISTRATOR = "Administrator";
        public const String MEMBER = "Member";        
    }
    #region UI CSS Classes
    public class UI
    {
        public const string ERROR_MESSAGE_CLASS = "ErrorMessage";
        public const string BOLD_MESSAGE_CLASS = "MessageCommon";
        public const string MESSAGE_BOX_CLASS = "MessageBox";
        public const string ERROR_MESSAGE_BOX_CLASS = "ErrorMessageBox";
    }
    #endregion

    #region Query String Params
    public class QueryString
    {
        public const string EXAM_ID = "ExamID";
        public const string QUESTION_ID = "QuestionID";
        public const string SHOW_RATING = "ShowRating";
        public const string SHOW_NEXT_QUESTION = "ShowNextQuestion";
        public const string QIESTION_RATED = "Rated";
        public const string CORRECT = "Correct";
        public const string QUESTION_NO = "QuestionNo";
        public const string QUESTION_KEYWORD = "Keyword";
        public const string QUESTION_CATEGORY = "Category";
        public const string IS_NEXT = "IsNext";
        public const string EXAM_KEY = "ExamKey";
        public const string EXAM_SESSION_ID = "ExamSessionID";
        public const string EXAM_ACTION = "Action";
        public const string ANSWER = "Answer";
        public const string ERROR_CODE = "ErrorCode";
        public const string USER_ID = "UserID";
        public const string VIEW_ALL = "ViewAll";
        public const string LINK = "Link";
        public const string LINK_ID = "LinkID";
        public const string ID = "ID";
        public const string LOG_OUT = "Logout";
    }
    
    #endregion

    #region Cookie Variables
    public class Cookie
    {
        public const string BASE = "Planningprep";
        public const string BASE_PLANNINGPREP_ANSWER = "PlanningPrepAnswer";
        public const string USER_CODE = "UserID";
        public const string AUTHOR_ID = "AuthorID";
        public const string MODE = "Mode";
        public const string REMEMBER_ME = "RememberMe";        
    }
    
    #endregion    

    #region Email Templates
    public class EmailTemplate
    {
        public const string GENERAL_EMAIL_TEMPLATE = "GeneralTemplate.html";
    }
    /// <summary>
    /// Custom Tag Constants in the Email Templates
    /// </summary>
    public class ETConstants
    {
        public const string MESSAGE = "[*MESSAGE*]";
    }
    #endregion
}
