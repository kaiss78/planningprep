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
        if (comment.UserID == SessionCache.CurrentUser.Author_ID)
            ltrThumbs.Text = "Thumbs Up<br/>Thumbs Down";
        else
            ltrThumbs.Text = String.Format("<a href='javascript:void(0);' onclick='ThumbsUp({0});'>Thumbs Up</a><br/><a href='javascript:void(0);' onclick='ThumbsDown({0});'>Thumbs Down</a>", comment.ID);
    }
}
