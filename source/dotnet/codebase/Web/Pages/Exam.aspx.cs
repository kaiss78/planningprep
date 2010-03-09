using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Domain.UserExams;
using App.Models.Exams;
using App.Core.Storage;

public partial class Pages_Exam : BasePage
{
    UserExamManager manager = new UserExamManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        IList<QuestionForExamType> questions = manager.GetQuestionsForExamType(3);
        
    }
}
