using System;
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
using App.Domain.UserExams;
using App.Models.UserExams;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
{
    protected UserExamManager examManager = new UserExamManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        //IList<UserExam> exams = examManager.GetList();
        //Response.Write(exams.Count);
        UserExam exam = examManager.Get(6631);
        examManager.Delete(exam);
        
        
    }
}
