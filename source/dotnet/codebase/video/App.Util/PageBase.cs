using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for PageBase
/// </summary>
namespace App.Util
{
    public class PagePage : System.Web.UI.Page
    {
        public delegate void ReloadFileList();
        public event ReloadFileList FileUploaded;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(SessionCache.CurrentUser == null)
            {
                Response.Redirect("~/Pages/Public/Login.aspx?ReturnUrl=" + HttpContext.Current.Request.Path);
            }
        }

        public void SignalFileUploaded()
        {
            if (FileUploaded != null)
            {
                FileUploaded();
            }
        }
    }
}