
#region References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Models.Users;
using App.Models.Exams;
using App.Domain.UserExams;

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
            CurrentExamKey = Guid.NewGuid().ToString();
        }
        return HttpContext.Current.Session[sessionKeyForExam] as IList<QuestionForExamType>;

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

    

    #endregion

    #region Methods

    /// <summary>
    /// Clears the session.
    /// </summary>
    public static void ClearSession()
    {
        HttpContext.Current.Session.Clear();
    }

    public static void SetExamStartTimeInfo()
    {
        HttpContext.Current.Session["EXAM_START_TIME"] = DateTime.Now;
    }

    public static DateTime GetExamStartTimeInfo()
    {
        if (HttpContext.Current.Session["EXAM_START_TIME"] == null)
        {
            return DateTime.MinValue;
        }
        return Convert.ToDateTime(HttpContext.Current.Session["EXAM_START_TIME"]);
    }

    public static void ClearExamSessionInfo()
    {
        HttpContext.Current.Session.Remove("EXAM_START_TIME");
        HttpContext.Current.Session.Remove("CURRENT_EXAM_KEY");
    }

    #endregion
}

#endregion
