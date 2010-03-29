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
using App.Util;
using App.Domain;
using App.Data;
using System.IO;

public partial class uc_WatchVideo : System.Web.UI.UserControl
{
    public int ItemNumber
    {
        get;
        set;
    }
     

    protected string ChapterUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        ChapterDefinitionFile file = SessionCache.CurrentFile;
        if (ItemNumber > 0)
        {
            VideoSectionItem item = SessionCache.GetVideoSectionItemByNumber(ItemNumber);
            if (item != null)
            {
                ChapterUrl = AppUtil.GetXmlUrlForItem(item, file.FileName);
            }
        }
        else
        {
            ChapterUrl = string.Format("{0}/{1}/{1}.xml", ConfigReader.XmlUrl, Path.GetFileNameWithoutExtension(file.FileName));
        }
    }
}
