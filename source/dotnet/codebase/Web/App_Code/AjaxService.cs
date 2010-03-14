using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;
using App.Models.Comments;

/// <summary>
/// Summary description for AjaxService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[ScriptService]    
public class AjaxService : System.Web.Services.WebService
{

    public AjaxService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod(EnableSession = true)]
    public String HelloWorld()
    {
        return "Hello World";
    }
    
    [WebMethod(EnableSession = true)]
    public long SaveComment(App.Models.Comments.Comment comment)
    {
        App.Domain.Comments.CommentManager manager = new App.Domain.Comments.CommentManager();        
        manager.SaveOrUpdate(comment);
        return comment.Id;
    }
    [WebMethod(EnableSession = true)]
    public void CommentThumbsUp(int commentID)
    {
        App.Domain.Comments.CommentManager manager = new App.Domain.Comments.CommentManager();
        Comment comment =  manager.Get(commentID);
        if (comment != null)
        {
            comment.Rank = comment.Rank + 1;
            manager.SaveOrUpdate(comment);
        }        
    }
    
    [WebMethod(EnableSession = true)]
    public void CommentThumbsDown(int commentID)
    {
        App.Domain.Comments.CommentManager manager = new App.Domain.Comments.CommentManager();
        Comment comment = manager.Get(commentID);
        if (comment != null)
        {
            if (comment.Rank > 0)
            {
                comment.Rank = comment.Rank - 1;
                manager.SaveOrUpdate(comment);
            }
        }        
    }
    

}

