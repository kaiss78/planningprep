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

public partial class UserControls_Commenting : BaseUserControl
{
    protected int _QuestionID;
    protected int _UserID;
    protected int _TotalCount;    
    protected String _CommentListDisplayStyle = "block";
    
    #region Properties
    public int QuestionID
    {
        get { return _QuestionID; }
        set { _QuestionID = value; }
    }
    #endregion Properties

    protected void Page_Load(object sender, EventArgs e)
    {
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
        Literal ltrComment = e.Item.FindControl("ltrComment") as Literal;
        ltrComment.Text = AppUtil.FormatText(comment.CommentText);
        Literal ltrThumbs = e.Item.FindControl("ltrThumbs") as Literal;
        String thumbsText = thumbsText = String.Format("+{0} Thumbs", comment.Rank);
            
        if (comment.UserID == SessionCache.CurrentUser.Author_ID)
            ltrThumbs.Text = String.Format("<div class='thumbText'>{0}&nbsp;</div><div class='thumbImage'><img src='/Images/ThumbsDown_Disabled.png' alt='Thumbs Down Disabled' title='Thumbs Down Disabled'/> <img src='/Images/ThumbsUp_Disabled.png' alt='Thumbs Up Disabled' title='Thumbs Up  Disabled'/></div><div class='clearfloating'></div>", GetLogicalText(comment.Rank - comment.NegativeRank, "Thumb"));
        else
            ltrThumbs.Text = String.Format("<div class='thumbText'>{0}&nbsp;</div><div class='thumbImage'><img src='/Images/ThumbsDown.png' onclick='ThumbsDown({1}, this);' alt='Thumbs Down this Comment' title='Thumbs Down this Comment' class='clickableimage'/> <img src='/Images/ThumbsUp.png' onclick='ThumbsUp({1}, this);' alt='Thumbs Up this Comment' title='Thumbs Up this Comment' class='clickableimage'/></div><div class='clearfloating'></div>", GetLogicalText(comment.Rank - comment.NegativeRank, "Thumb"), comment.ID);
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
        else if (count < -1)
            return String.Format("{0} {1}s", count, textToUse);
        else if (count == 0)
            return String.Format("0 {0}s", textToUse);
        else 
            return String.Format("+1 {0}", textToUse);
        
    }
}
