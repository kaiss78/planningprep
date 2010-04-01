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

            if (Request.FilePath.ToLower().EndsWith("admin/uploadfile.aspx"))
            {
                bool redirect = false;
                if (!Page.User.Identity.IsAuthenticated)
                {
                    redirect = true;

                }
                else
                {
                    if (!Page.User.IsInRole("Administrators"))
                    {
                        redirect = true;
                    }
                }

                if (redirect)
                {
                    Response.Redirect("~/Login.aspx?ReturnUrl=" + Request.Path);
                }
            }

            else
            {

                if (SessionCache.CurrentUser == null)
                {
                    Response.Redirect("~/Pages/Public/Login.aspx?ReturnUrl=" + HttpContext.Current.Request.Path);
                }
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