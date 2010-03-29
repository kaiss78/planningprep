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
    public class PagePage : Page
    {
        public delegate void ReloadFileList();
        public event ReloadFileList FileUploaded;

        
        public void SignalFileUploaded()
        {
            if (FileUploaded != null)
            {
                FileUploaded();
            }
        }
    }
}