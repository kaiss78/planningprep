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
using System.IO;
using App.Util;
using System.Collections.Generic;
using App.Domain;

public partial class Pages_Admin_GenerateSerialKeys : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string serialKeyPath = Path.Combine(Server.MapPath("~/"), "SerialKeys.xlsx");
        List<string> serialKeys = ExelHelper.Instance.ReadSerialKeysFromExcel(serialKeyPath);

        SerialKeyManager mgr = new SerialKeyManager();

        foreach (string key in serialKeys)
        {
            mgr.Save(key);   
        }

    }
}
