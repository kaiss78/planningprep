using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;

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
    public string SaveComment(App.Models.Comments.Comment comment)
    {
        App.Domain.Comments.CommentManager manager = new App.Domain.Comments.CommentManager();        
        manager.SaveOrUpdate(comment);
        return "Saved Successfully";
    }

}

