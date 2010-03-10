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

public partial class Default : System.Web.UI.Page
{
    protected int _NumberOfQuestions;
    protected String _LastQuestionDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        SetInitialValues();
    }

    private void SetInitialValues()
    {
        App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
        _NumberOfQuestions = manager.GetPagedList(1, int.MaxValue).Count;
        _LastQuestionDate = DateTime.Now.ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY_WITH_TIME);
        //manager.
    }
}
