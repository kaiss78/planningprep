
#region References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Models.Users;
using App.Models.Exams;
using App.Domain.UserExams;
using App.Models.Questions;

#endregion

#region Class

/// <summary>
/// Acts as a facade to cached data stored at the Session scope
/// </summary>
public class SessionCache
{
    #region Constructor

    public SessionCache()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Instance

    /// <summary>
    /// SessionCache instance property
    /// </summary>

    //private static SessionCache _instance = new SessionCache(); 
    public static SessionCache Instance
    {
        get
        {
            return new SessionCache();
        }
    }

    #endregion

    #region Properties
    public static int FailedLoginAttemptCount
    {
        get
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["FAILED_LOGIN_ATTEMP_COUNT"] == null)
                return 0;
            return Convert.ToInt32(HttpContext.Current.Session["FAILED_LOGIN_ATTEMP_COUNT"]);
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["FAILED_LOGIN_ATTEMP_COUNT"] = value;
            }
        }
    }
    public static String AttemptedUserName
    {
        get
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["ATTEMPTED_USER_NAME"] == null)
                return String.Empty;
            return Convert.ToString(HttpContext.Current.Session["ATTEMPTED_USER_NAME"]);
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["ATTEMPTED_USER_NAME"] = value;
            }
        }
    }
    /// <summary>
    /// Currently logged in user in the system
    /// </summary>
    public static PlanningPrepUser CurrentUser
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            if (HttpContext.Current.Session["CURRENT_USER"] == null) return null;
            return HttpContext.Current.Session["CURRENT_USER"] as PlanningPrepUser;
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CURRENT_USER"] = value;
            }
        }
    }

    

    /// <summary>
    /// Current exam questions that user is navigating through
    /// </summary>
    public static IList<Questions> CurrentQuestionList
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            if (HttpContext.Current.Session["CURRENT_QUESTION_LIST"] == null) return null;
            return HttpContext.Current.Session["CURRENT_QUESTION_LIST"] as IList<Questions>;
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CURRENT_QUESTION_LIST"] = value;
            }
        }
    }

    /// <summary>
    /// Current exam questions that user is navigating through
    /// </summary>
    public static IList<QuestionForExamType> CurrentBookmarkedQuestions
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            if (HttpContext.Current.Session["CURRENT_BOOKMARKED_QUESTION_LIST"] == null) return null;
            return HttpContext.Current.Session["CURRENT_BOOKMARKED_QUESTION_LIST"] as IList<QuestionForExamType>;
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CURRENT_BOOKMARKED_QUESTION_LIST"] = value;
            }
        }
    }

    public static Questions GetNextQuestion(int currentQuestionID)
    {
        IList<Questions> questions = CurrentQuestionList;
        string Keyword = CurrentQuestionSearchCriteriaForKeyword;
        string Category = CurrentQuestionSearchCriteriaForCategory;

        Questions nextQuestion = null;

        if (questions != null)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].QuestionID == currentQuestionID && i + 1 < questions.Count)
                {
                    nextQuestion = questions[i + 1];
                }
            }
        }

        if (nextQuestion == null)
        {
            //Reload the questions based upon the current criteria
            int pageSize = ConfigReader.AdminQuestionListSize;
            App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
            int pageNo = CurrentQuestionPageNo + 1;
            CurrentQuestionPageNo = pageNo;

            if (string.IsNullOrEmpty(Keyword) && string.IsNullOrEmpty(Category))
            {
                questions = manager.GetPagedList(pageNo, 1000000).ToList();
            }
            else
            {
                bool filter = false;
                if (SessionCache.CurrentUser != null)
                {
                    if (SessionCache.CurrentUser.Mode == "Filtered")
                    {
                        filter = true;
                    }
                }
                questions = manager.GetPagedListByKeywordOrCategory(pageNo, 10000000, Keyword, Category, SessionCache.CurrentUser.Author_ID, filter).ToList();
            }

            CurrentQuestionList = questions;

            if (questions != null)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    if (questions[i].QuestionID == currentQuestionID && i + 1 < questions.Count)
                    {
                        nextQuestion = questions[i + 1];
                    }
                }
            }
        }

        return nextQuestion;
    }

    /// <summary>
    /// Current  questions search criteria for keyword that user is navigating through
    /// </summary>
    public static string CurrentQuestionSearchCriteriaForKeyword
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            if (HttpContext.Current.Session["CURRENT_QUESTION_SEARCH_CRITERIA_FOR_KEYWORD"] == null) return null;
            return HttpContext.Current.Session["CURRENT_QUESTION_SEARCH_CRITERIA_FOR_KEYWORD"] as string;
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CURRENT_QUESTION_SEARCH_CRITERIA_FOR_KEYWORD"] = value;
            }
        }
    }

    /// <summary>
    /// Current  questions search criteria for keyword that user is navigating through
    /// </summary>
    public static string CurrentQuestionSearchCriteriaForCategory
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            if (HttpContext.Current.Session["CURRENT_QUESTION_SEARCH_CRITERIA_FOR_CATEGORY"] == null) return null;
            return HttpContext.Current.Session["CURRENT_QUESTION_SEARCH_CRITERIA_FOR_CATEGORY"] as string;
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CURRENT_QUESTION_SEARCH_CRITERIA_FOR_CATEGORY"] = value;
            }
        }
    }

    /// <summary>
    /// Current  questions page no. that the user is navigating through
    /// </summary>
    public static int CurrentQuestionPageNo
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return 1;
            }
            if (HttpContext.Current.Session["CURRENT_QUESTION_LIST_PAGE_NO"] == null) return 0;
            return Convert.ToInt32(HttpContext.Current.Session["CURRENT_QUESTION_LIST_PAGE_NO"]);
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CURRENT_QUESTION_LIST_PAGE_NO"] = value;
            }
        }
    }

    /// <summary>
    /// Get exam questions for Exam type from Session
    /// </summary>
    public IList<QuestionForExamType> GetExamQuestionsForExamType(int ExamID)
    {
        UserExamManager manager = new UserExamManager();

        if (HttpContext.Current.Session == null)
        {
            return null;
        }

        string sessionKeyForExam = WebUtil.GetExamKeyForExamType(ExamID);

        if (HttpContext.Current.Session[sessionKeyForExam] == null)
        {
            IList<QuestionForExamType> questions = manager.GetQuestionsForExamType(ExamID);
            HttpContext.Current.Session[sessionKeyForExam] = questions;
        
        }
        return HttpContext.Current.Session[sessionKeyForExam] as IList<QuestionForExamType>;

    }


    /// <summary>
    /// Determines whether an Exam is ongoing for the user
    /// </summary>
    public static bool ExamOngoing
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return false;
            }
            if (HttpContext.Current.Session["EXAM_ONGOING"] == null) return false;
            return Convert.ToBoolean(HttpContext.Current.Session["EXAM_ONGOING"]);
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["EXAM_ONGOING"] = value;
            }
        }
    }

    /// <summary>
    /// Determines whether the ongoing exam is for the Bookmarked questions
    /// </summary>
    public static bool BookmarkedExamOngoing
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return false;
            }
            if (HttpContext.Current.Session["BOOKMARKED_EXAM_ONGOING"] == null) return false;
            return Convert.ToBoolean(HttpContext.Current.Session["BOOKMARKED_EXAM_ONGOING"]);
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["BOOKMARKED_EXAM_ONGOING"] = value;
            }
        }
    }

    /// <summary>
    /// CurrentExamKey
    /// </summary>
    public static string CurrentExamKey
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            if (HttpContext.Current.Session["CURRENT_EXAM_KEY"] == null) return null;
            return HttpContext.Current.Session["CURRENT_EXAM_KEY"] as string;
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CURRENT_EXAM_KEY"] = value;
            }
        }
    }

    /// <summary>
    /// CurrentExamKey
    /// </summary>
    public static int AnsweredQuestionCount
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return 0;
            }
            if (HttpContext.Current.Session["ANSWERED_QUESTION_COUNT"] == null) return 0;
            return Convert.ToInt32(HttpContext.Current.Session["ANSWERED_QUESTION_COUNT"]);
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["ANSWERED_QUESTION_COUNT"] = value;
            }
        }
    }
    public static IList<PlanningPrepUser> SelectedUsersForEmail
    {
        get
        {
            if (HttpContext.Current.Session == null)
                return null;
            if (HttpContext.Current.Session["SELECTED_USERS_FOR_EMAIL"] == null) return null;
            return HttpContext.Current.Session["SELECTED_USERS_FOR_EMAIL"] as IList<PlanningPrepUser>;
                 
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["SELECTED_USERS_FOR_EMAIL"] = value;
            }
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Clears the session.
    /// </summary>
    public static void ClearSession()
    {
        HttpContext.Current.Session.Clear();
    }

    public static void SetExamStartTime(DateTime dateTime)
    {
        HttpContext.Current.Session["EXAM_START_TIME"] = dateTime;
    }

    public static DateTime GetExamStartTime()
    {
        if (HttpContext.Current.Session["EXAM_START_TIME"] == null)
        {
            return DateTime.MinValue;
        }
        return Convert.ToDateTime(HttpContext.Current.Session["EXAM_START_TIME"]);
    }

    public static void SetCurrentQuestionNo(int QuestionNo)
    {
        HttpContext.Current.Session["CURRENT_QUESTION"] = QuestionNo;
    }

    public static void SetBookmarkedCurrentQuestionNo(int QuestionNo)
    {
        HttpContext.Current.Session["CURRENT_BOOKMARKED_QUESTION"] = QuestionNo;
    }

    public static int GetBookmarkedCurrentQuestionNo()
    {
        int QuestionNo = Convert.ToInt32(HttpContext.Current.Session["CURRENT_BOOKMARKED_QUESTION"]);
        return QuestionNo;
    }

    public static int GetCurrentQuestionNo()
    {
        int QuestionNo = Convert.ToInt32(HttpContext.Current.Session["CURRENT_QUESTION"]);
        return QuestionNo;
    }

    public static void SetDateTimeInfoForCurrentQuestion()
    {
        if (HttpContext.Current.Session["CURRENT_QUESTION_START_TIME"] == null)
        {
            HttpContext.Current.Session["CURRENT_QUESTION_START_TIME"] = DateTime.Now;
        }
    }

    public static DateTime GetDateTimeInfoForCurrentQuestion()
    {
        return Convert.ToDateTime(HttpContext.Current.Session["CURRENT_QUESTION_START_TIME"]);
    }

    public static void SetCurrentExamSessionID(int ExamSessionID)
    {
        HttpContext.Current.Session["CURRENT_EXAM_SESSION_ID"] = ExamSessionID;
    }

    public static int GetCurrentExamSessionID()
    {
        int ExamSessionID = Convert.ToInt32(HttpContext.Current.Session["CURRENT_EXAM_SESSION_ID"]);
        return ExamSessionID;
    }

    public static void ClearExamSessionInfo()
    {
        HttpContext.Current.Session.Remove("EXAM_START_TIME");
        HttpContext.Current.Session.Remove("CURRENT_EXAM_KEY");
        HttpContext.Current.Session.Remove("EXAM_ONGOING");
        HttpContext.Current.Session.Remove("CURRENT_QUESTION");
        HttpContext.Current.Session.Remove("CURRENT_QUESTION_START_TIME");
        HttpContext.Current.Session.Remove("CURRENT_EXAM_SESSION_ID");
        HttpContext.Current.Session.Remove("ANSWERED_QUESTION_COUNT");
        HttpContext.Current.Session.Remove("CURRENT_BOOKMARKED_QUESTION");
        HttpContext.Current.Session.Remove("CURRENT_BOOKMARKED_QUESTION_LIST");
        HttpContext.Current.Session.Remove("BOOKMARKED_EXAM_ONGOING");

    }

    #endregion
}

#endregion
