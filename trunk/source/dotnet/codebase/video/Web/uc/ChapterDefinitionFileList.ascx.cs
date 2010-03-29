using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Util;
using System.IO;
using App.Domain;
using App.Data;

public partial class uc_ChapterDefinitionFileList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        (this.Page as PageBase).FileUploaded += new PageBase.ReloadFileList(uc_ChapterDefinitionFileList_FileUploaded);
        BindFileList();
    }

    void uc_ChapterDefinitionFileList_FileUploaded()
    {
        BindFileList();
    }

    protected  void BindFileList()
    {
        string chapterFolder = AppUtil.GetUploadFolderForExel();
        if (Directory.Exists(chapterFolder))
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

            string fileName = Path.GetFileName(file);
            ChapterDefinitionFile chapterFile = ChapterFileManager.Instance.GetByFileName(fileName);
            
            Label lblFileName = e.Item.FindControl("lblFile") as Label;
            LinkButton hplDownload = e.Item.FindControl("hplDownload") as LinkButton;
            LinkButton hplDelete = e.Item.FindControl("hplDelete") as LinkButton;
            HyperLink hplChapters = e.Item.FindControl("hplChapters") as HyperLink;

            if (chapterFile != null)
            {
                lblFileName.Text = Path.GetFileName(file);
                hplDownload.CommandArgument = file;
                hplDelete.CommandArgument = file;

                hplChapters.NavigateUrl = string.Format("~/Pages/Public/ViewChapters.aspx?FileId={0}", chapterFile.Id);
            }
            else
            {
                lblFileName.Visible = false;
                hplDelete.Visible = false;
                hplDownload.Visible = false;
                hplChapters.Visible = false;
            }
        }
    }


    protected void rptFileList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "Download")
        {
            Response.AppendHeader("Content-Type", "application/vnd.ms-excel");
            Response.AppendHeader("Content-disposition", "attachment; filename=" + Path.GetFileName(e.CommandArgument.ToString()));
            
            Response.WriteFile(e.CommandArgument.ToString());
        }
        else if(e.CommandName == "Delete")
        {
            string file = e.CommandArgument.ToString();
            if(File.Exists(file))
            {
                File.Delete(file);

                string xmlDir = Path.Combine(AppUtil.GetUploadFolderForXml(), Path.GetFileNameWithoutExtension(file));
                Directory.Delete(xmlDir,true);

                ChapterDefinitionFile chapterFile = ChapterFileManager.Instance.GetByFileName(Path.GetFileName(file));
                if (chapterFile != null)
                {
                    ChapterFileManager.Instance.Delete(chapterFile);
                }
            }
        }

        BindFileList();
    }
}
