using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Util;
using System.IO;

public partial class uc_ChapterDefinitionFileList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string chapterFolder = AppUtil.GetUploadFolderForExel();
        if(Directory.Exists(chapterFolder))
        {
            string[] exelFiles = Directory.GetFiles(chapterFolder);
            rptFileList.DataSource = exelFiles;
            rptFileList.DataBind();
        }
    }

    protected void rptFileList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            string file = e.Item.DataItem as string;

            Label lblFileName = e.Item.FindControl("lblFile") as Label;
            lblFileName.Text = Path.GetFileName(file);
        }
    }


}
