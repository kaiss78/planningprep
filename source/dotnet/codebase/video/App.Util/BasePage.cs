using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for BasePage
/// </summary>
namespace App.Util
{
    public class BasePage : Page
    {
        public delegate void ReloadFileList();
        public event ReloadFileList FileUploaded;

        public PageBase()
        {
            //
            // TODO: Add constructor logic here
            //
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