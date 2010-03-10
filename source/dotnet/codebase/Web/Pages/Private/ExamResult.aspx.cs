using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Domain.UserExams;
using App.Models.UserExams;

public partial class Pages_Private_ExamResult : System.Web.UI.Page
{
    int ExamSessionID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ExamSessionID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.EXAM_SESSION_ID);
        if (ExamSessionID == 0)
        {
            return;
        }
        FinishExam();
    }

    private void FinishExam()
    {
        DateTime examStartTime = SessionCache.GetExamStartTimeInfo();
        UserExamManager userExamManager = new UserExamManager();
        
        UserExam currentUserExam = userExamManager.Get(ExamSessionID);

        currentUserExam.TotalTime += DateTime.Now.Subtract(examStartTime).Seconds;
        currentUserExam.EndDate = DateTime.Now;
        
        userExamManager.SaveOrUpdateSavedQuestion(null, currentUserExam);
    }

    

}
