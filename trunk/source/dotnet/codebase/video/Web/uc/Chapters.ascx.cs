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

    protected string RootXmlUrl
    {
        get;
        set;
    }
    ChapterFileManager manager = new ChapterFileManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<ChapterDefinitionFile> files = manager.GetAll();

        if (!IsPostBack)
        {
            foreach (ChapterDefinitionFile file in files)
            {
                ListItem item = new ListItem(Path.GetFileNameWithoutExtension(file.FileName), file.Id.ToString());
                
                ddlChapterFiles.Items.Add(item);
                if (ExelFileId == file.Id)
                {
                    item.Selected = true;
                }
            }
        }

        if (ExelFileId == 0 && files!= null && files.Count > 0)
        {
            ExelFileId = files[0].Id;
        }
        PopuplateUI(ExelFileId);
    }

    protected void PopuplateUI(int fileId)
    {
        ChapterDefinitionFile file = manager.GetById(fileId);
        if (file != null)
        {
            string exelFileName = Path.Combine(AppUtil.GetUploadFolderForExel(), file.FileName);
            SessionCache.CurrentFile = file;
            if (File.Exists(exelFileName))
            {
                RootXmlUrl = string.Format("{0}/{1}/{1}.xml", ConfigReader.XmlUrl, Path.GetFileNameWithoutExtension(file.FileName));
                List<VideoSectionItem> items = ExelHelper.Instance.GetDataFromExcel(exelFileName);
                SessionCache.VideoSectionItems = items;
                int levelCount = ExelHelper.Instance.GetLevelCount(items);

                List<VideoSectionItem> hirarchialItems = DataParser.Instance.GetHirararchialVideoSectionItems(items, Server.MapPath(ConfigReader.XmlDir), levelCount, file.FileName);

                string response = HtmlHelper.Instance.GetResponseForItems(hirarchialItems, file);
                divChapters.InnerHtml = response;
            }
        }
    }

    protected void ddlChapterFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        int fileId = Convert.ToInt32(ddlChapterFiles.SelectedValue);
        Response.Redirect("ViewChapters.aspx?FileID=" + fileId);
    }
}
