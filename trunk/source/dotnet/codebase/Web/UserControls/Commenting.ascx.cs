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
using System.Collections.Generic;
using App.Models.Comments;
using App.Domain.Comments;
using App.Domain.Users;
using App.Models.Users;
using System.Text;

public partial class UserControls_Commenting : BaseUserControl
{
    protected int _QuestionID;
    protected int _UserID;
    protected int _TotalCount;
    protected String _CommentListDisplayStyle = "block";
    private UserManager _UserManager = null;
    private CommentThumbInfoManager _ThumbInfoManager = null;

    #region Properties
    public int QuestionID
    {
        get { return _QuestionID; }
        set { _QuestionID = value; }
    }
    #endregion Properties

    protected void Page_Load(object sender, EventArgs e)
    {
        _UserManager = new UserManager();
        _ThumbInfoManager = new CommentThumbInfoManager();
        _UserID = SessionCache.CurrentUser.Author_ID;
        BindCommentList();
    }
    protected void BindCommentList()
    {
        CommentManager manager = new CommentManager();
        IList<Comment> comments = manager.GetCommentsByQuestion(this.QuestionID);
        _TotalCount = comments.Count;
        rptCommentList.DataSource = comments;
        rptCommentList.DataBind();

        if (_TotalCount > 0)
            //ltrCommentHeading.Text = "<a href='javascript:void(0);' onclick='ToggleCommentingBox();'>Write your comment here.</a>";
            ltrCommentHeading.Text = "<a href='javascript:void(0);' onclick='ToggleCommentingBox();'>Comment</a>";
        else
        {
            _CommentListDisplayStyle = "none";
            //ltrCommentHeading.Text = "<a href='javascript:void(0);' onclick='ToggleCommentingBox();'>Be the first to comment on this question.</a>";
            ltrCommentHeading.Text = "<a href='javascript:void(0);' onclick='ToggleCommentingBox();'>Comment</a>";
        }

    }
    protected void rptCommentList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Comment comment = e.Item.DataItem as Comment;
        PlanningPrepUser user = _UserManager.Get(comment.UserID);
        if (user != null)
        {
            Literal ltrUserInfo = e.Item.FindControl("ltrUserInfo") as Literal;
            ltrUserInfo.Text = String.Format("{0}<br /><span class='minutesago'>{1}</span>", AppUtil.Encode(user.Username), GetDifference(comment.Created));
        }
        Literal ltrComment = e.Item.FindControl("ltrComment") as Literal;
        ltrComment.Text = string.Format("\"{0}\"", AppUtil.FormatText(comment.CommentText));
        Literal ltrThumbs = e.Item.FindControl("ltrThumbs") as Literal;
        String thumbsText = thumbsText = String.Format("+{0} Thumbs", comment.Rank);

        if (comment.UserID == SessionCache.CurrentUser.Author_ID || _ThumbInfoManager.HasThumbed(SessionCache.CurrentUser.Author_ID, _QuestionID, comment.ID))
            ltrThumbs.Text = String.Format("<div class='thumbText'>{0}&nbsp;</div><div class='thumbImage'><img src='/Images/ThumbsDown_Disabled.png' alt='Thumbs Down Disabled' title='Thumbs Down Disabled'/> <img src='/Images/ThumbsUp_Disabled.png' alt='Thumbs Up Disabled' title='Thumbs Up  Disabled'/></div><div class='clearfloating'></div>", GetLogicalText(comment.Rank - comment.NegativeRank, "Thumb"));
        else
            ltrThumbs.Text = String.Format("<div class='thumbText'>{0}&nbsp;</div><div class='thumbImage'><img src='/Images/ThumbsDown.png' onclick='ThumbsDown({1}, this);' alt='Thumbs Down this Comment' title='Thumbs Down this Comment' class='clickableimage'/> <img src='/Images/ThumbsUp.png' onclick='ThumbsUp({1}, this);' alt='Thumbs Up this Comment' title='Thumbs Up this Comment' class='clickableimage'/></div><div class='clearfloating'></div>", GetLogicalText(comment.Rank - comment.NegativeRank, "Thumb"), comment.ID);

        HtmlGenericControl divCommentReplyes = e.Item.FindControl("divCommentReplyes") as HtmlGenericControl;
        divCommentReplyes.InnerHtml = GetCommentReplyHtml(comment, e.Item);
    }

    protected String GetCommentReplyHtml(Comment comment, RepeaterItem item)
    {
        CommentReplyManager manager = new CommentReplyManager();
        IList<CommentReply> replyes = manager.GetCommentReplyByCommentID(comment.ID);
        HtmlGenericControl divReply = item.FindControl("divReply") as HtmlGenericControl;
        HyperLink hplReply = item.FindControl("hplReply") as HyperLink;

        if (replyes != null && replyes.Count > 0)
        {
            ///Show the Reply Link
            divReply.Visible = true;
            hplReply.Attributes["onclick"] = String.Format("ShowPopupForCommentReply({0}, this);", comment.ID);

            UserManager userManager = new UserManager();
            StringBuilder sb = new StringBuilder(10);
            #region Expand Collapse Implementation
            //sb.Append("Comment Replyes:");
            //foreach (CommentReply reply in replyes)
            //{
            //    PlanningPrepUser user = userManager.Get(reply.UserID);
            //    sb.Append("<div style='margin-top:10px;'>");
            //    sb.Append("<div class='ExamTitle' onclick='ToggleCollapse(this)' style='cursor:pointer'>");
            //    sb.AppendFormat("<img class='clickableimage' src='/Images/plus.gif' alt='Expand' title='Expand'/> {0}", user.Username);
            //    sb.Append("</div>");
            //    sb.AppendFormat("<div class='replymessage' style='display:none;'>{0}</div>", AppUtil.FormatText(reply.Message));
            //    sb.Append("</div>");
            //}
            #endregion


            for(int i=0; i<replyes.Count; i++) 
            {
                CommentReply reply = replyes[i];
                PlanningPrepUser user = userManager.Get(reply.UserID);
                if (i == 0)
                    sb.Append("<div class='replymessagecontainer' style='margin-top:10px;'>");
                else
                    sb.Append("<div class='replymessagecontainer'>");
                sb.AppendFormat("Reply of <b>{0}</b><br />", AppUtil.Encode(user.Username));
                sb.Append(AppUtil.FormatText(reply.Message));                
                sb.Append("</div>");
            }

            return sb.ToString();
        }
        else
        {
            ///Show the Reply Link if this commment is not the users own comment
            if (comment.UserID != SessionCache.CurrentUser.Author_ID)
            {
                divReply.Visible = true;
                hplReply.Attributes["onclick"] = String.Format("ShowPopupForCommentReply({0});", comment.ID);
            }
        }
        return String.Empty;
    }

    private String GetDifference(DateTime commentTime)
    {
        double minutes = DateTime.Now.Subtract(commentTime).TotalMinutes;
        minutes = Math.Ceiling(minutes);
        if (minutes < 60)
            return String.Format("{0} ago", GetPluralText(minutes, "Minute"));
        else
        {
            double hour = Math.Floor(minutes / 60);
            if (hour < 24)
            {
                double remainingMinute = minutes % 60;
                return String.Format("{0} {1} ago", GetPluralText(hour, "Hour"), GetPluralText(remainingMinute, "Minute"));
            }
            else
            {
                double day = Math.Floor(hour / 24);
                //postfix = "Hour(s) ago";
                if (day < 30)
                {
                    double remainingHours = hour % 24;
                    return String.Format("{0} {1} ago", GetPluralText(day, "Day"), GetPluralText(remainingHours, "Hour"));
                }
                else
                {
                    double month = Math.Floor(day / 30);
                    if (month < 12)
                    {
                        double remainingDays = day % 30;
                        return String.Format("{0} {1} ago", GetPluralText(month, "Month"), GetPluralText(remainingDays, "Day"));
                    }
                    else
                    {
                        double year = Math.Floor(month / 12);
                        double remainingMonth = month % 12;
                        return String.Format("{0} {1} ago", GetPluralText(year, "Year"), GetPluralText(remainingMonth, "Month"));
                    }
                }
            }
        }
    }
    protected String GetPluralText(double value, String text)
    {
        if (value == 0 || value > 1)
        {
            if (value == 0 && text != "Minute")
                return String.Empty;
            else
                return String.Format("{0} {1}s", value, text);
        }
        else //if(value == 1)
            return String.Format("{0} {1}", value, text);
    }

    /// <summary>
    /// Gets Logical Text Depending on different input count
    /// </summary>
    /// <param name="count"></param>
    /// <param name="textToUse"></param>
    /// <returns></returns>
    protected String GetLogicalText(int count, String textToUse)
    {
        if (count > 1)
            return String.Format("+{0} {1}s", count, textToUse);
        else if (count < 0)
        {
            if (count == -1)
                return String.Format("{0} {1}", count, textToUse);
            else// if (count < -1)
                return String.Format("{0} {1}s", count, textToUse);
        }
        //else if (count < -1)
        //    return String.Format("{0} {1}s", count, textToUse);
        else if (count == 0)
            return String.Format("0 {0}s", textToUse);
        else
            return String.Format("+1 {0}", textToUse);

    }
}
