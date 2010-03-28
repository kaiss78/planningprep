using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Domain;
using System.IO;
using App.Data;
using App.Util;

public partial class uc_Chapters : System.Web.UI.UserControl
{
    public int ExelFileId
    {
        get; set;
    }

    ChapterFileManager manager = new ChapterFileManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        ChapterDefinitionFile file = manager.GetById(ExelFileId);
        if (file != null)
        {
            string exelFileName = Path.Combine(AppUtil.GetUploadFolderForExel(), file.FileName);
            SessionCache.CurrentFile = file;
            if (File.Exists(exelFileName))
            {
                List<VideoSectionItem> items = ExelHelper.Instance.GetDataFromExcel(exelFileName);
                SessionCache.VideoSectionItems = items;
                int levelCount = ExelHelper.Instance.GetLevelCount(items);

                List<VideoSectionItem> hirarchialItems = DataParser.Instance.GetHirararchialVideoSectionItems(items, Server.MapPath(ConfigReader.XmlDir), levelCount, file.FileName);

                string response = HtmlHelper.Instance.GetResponseForItems(hirarchialItems, file);
                divChapters.InnerHtml = response;
            }
        }
    }
}
