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

public partial class UserControls_Chart : BaseUserControl
{
    protected double PercentageOfA;
    protected double PercentageOfB;
    protected double PercentageOfC;
    protected double PercentageOfD;
    protected double TotalResponse;

    public int QuestionID
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        App.Domain.AnswerTotals.AnswerTotalManager manager = new App.Domain.AnswerTotals.AnswerTotalManager();
        App.Models.AnswerTotals.AnswerTotal answerTotal = manager.Get(this.QuestionID);
        if (answerTotal != null)
        {
            PercentageOfA = Math.Round(answerTotal.A > 0 ? (Convert.ToDouble(answerTotal.A) / Convert.ToDouble(answerTotal.Total)) : answerTotal.A ,2);
            PercentageOfB = Math.Round(answerTotal.B > 0 ? (Convert.ToDouble(answerTotal.B) / Convert.ToDouble(answerTotal.Total)) : answerTotal.B, 2);
            PercentageOfC = Math.Round(answerTotal.C > 0 ? (Convert.ToDouble(answerTotal.C) / Convert.ToDouble(answerTotal.Total)) : answerTotal.C, 2);
            PercentageOfD = Math.Round(answerTotal.D > 0 ? (Convert.ToDouble(answerTotal.D) / Convert.ToDouble(answerTotal.Total)) : answerTotal.D, 2);
            TotalResponse = answerTotal.Total;
        }
    }
    protected int ConvertPercentageToPixel(double percentage)
    {
        int actualPercentage = Convert.ToInt32(percentage * 100);
        return (actualPercentage * 197) / 100;        
    }
    protected int FormatPercent(double percentage)
    {
        return Convert.ToInt32(percentage * 100);
    }
}
