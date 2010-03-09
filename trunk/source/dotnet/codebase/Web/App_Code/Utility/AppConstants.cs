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

    public class Pages
    {
        public const string EDIT_QUESTION = "/Pages/Private/Admin/EditQuestion.aspx";
        public const string MANAGE_QUESTIONS = "/Pages/Private/Admin/ManageQuestions.aspx";
    }
    public class ValueOf
    {
        public const string CALENDAR_DATE_FORMAT = "dd/MM/yyyy";
        public const string DECIMAL_FORMAT = "{0:0,0.00}";
        public const string DECIMAL_FORMAT_CALCULATION = "{0:00.####}";
        public const string DATE_FROMAT_DISPLAY = "MMMM dd, yyyy";
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
        public const string QUESTION_ID = "QuestionID";
        public const string EXAM_ID = "ExamID";
        public const string QUESTION_NO = "QuestionNo";
        public const string IS_NEXT = "IsNext";
        public const string EXAM_KEY = "ExamKey";
        public const string EXAM_SESSION_ID = "ExamSessionID";
        public const string EXAM_ACTION = "Action";
    }
    
    #endregion

    #region Cookie Variables
    public class Cookie
    {
        public const string BASE = "PlanningPrep";    
    }
    
    #endregion    
}
