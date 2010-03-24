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
using App.Domain.Links;
using App.Models.Links;
using System.Text;

public partial class LinkToComment : System.Web.UI.Page
{
    private int _TotalImportedLink;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Convert Link to Comment");
        if (!IsPostBack)
        {
            //CommentManager commentManager = new CommentManager();
            //IList<Comment> comments = commentManager.GetList();
            //LinkManager linkManager = new LinkManager();
            //Link link = linkManager.Get(990);
            //IList<Link> links = linkManager.GetLinksForQuestion(43);
            //if(IsLinkAlreadyImported(links[0], comments))
            //{
            //    Console.WriteLine("Link found in the comments table");
            //}
        }
    }
    protected void btnImportLinks_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
            IList<App.Models.Questions.Questions> questions = manager.GetList();
            if (questions != null && questions.Count > 0)
            {
                ImportLinksToCommentTable(questions);
                divMessage.InnerHtml = String.Format("Total {0} Links Imported to the Comments Table.", _TotalImportedLink);
            }
        }
    }

    protected void ImportLinksToCommentTable(IList<App.Models.Questions.Questions> questions)
    {
        CommentManager commentManager = new CommentManager();
        IList<Comment> comments = commentManager.GetList();
        LinkManager linkManager = new LinkManager();
        foreach (App.Models.Questions.Questions question in questions)
        {
            IList<Link> links = linkManager.GetLinksForQuestion(question.QuestionID);
            if(links != null && links.Count > 0)
                AddLinksToTheCommentTable(links, comments, question.QuestionID);
        }
    }

    private void AddLinksToTheCommentTable(IList<Link> links, IList<Comment> comments, int questionID)
    {
        CommentManager manager = new CommentManager();
        foreach (Link link in links)
        {
            if (!IsLinkAlreadyImported(link, comments, questionID))
            {
                ///Add the Link As Comment
                Comment comment = ConvertLinkToComment(link, questionID);
                manager.SaveOrUpdate(comment);
                _TotalImportedLink++;
            }
        }
    }

    private Comment ConvertLinkToComment(Link link, int questionID)
    {
        Comment comment = new Comment();
        comment.LinkID = link.LinkID;
        comment.QuestionID = questionID;
        
        ///User ID Should be "Devine" according to client requirement        
        comment.UserID = ConfigReader.UserIDForLinkToCommentConversion;
        //OR
        //comment.UserID = SessionCache.CurrentUser.Author_ID;

        if (link.TimeStamp == DateTime.MinValue)
        {
            comment.Created = DateTime.Now;
            comment.Modified = DateTime.Now;
        }
        else
        {
            comment.Created = link.TimeStamp;
            comment.Modified = link.TimeStamp;
        }
        comment.CommentText = GetLinkTextForCommentText(link);
        return comment;

    }
    private String GetLinkTextForCommentText(Link link)
    {
        StringBuilder sb = new StringBuilder(10);
        String url = String.Format("{0}?{1}={2}&{3}={4}", AppConstants.Pages.VISIT_FRAME, AppConstants.QueryString.LINK_ID, link.LinkID, AppConstants.QueryString.LINK, Server.UrlEncode(link.LinkOriginal));
        ///Pages/Public/VisitFrame.aspx?Link
        sb.AppendFormat("<a href='{0}' target='_blank'>{1}</a><br/>", url, link.LinkTitle);
        sb.Append(link.LinkDescription);
        return sb.ToString();
    }

    protected bool IsLinkAlreadyImported(Link link, IList<Comment> comments, int questionID)
    {
        var comment = from P in comments
                      where P.LinkID == link.LinkID && P.QuestionID == questionID
                      select P;
        if (comment == null || comment.Count() == 0)
            return false;
        return true;        
    }

}
