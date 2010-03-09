
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
        }
        return HttpContext.Current.Session[sessionKeyForExam] as IList<QuestionForExamType>;

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

    #endregion
}

#endregion
