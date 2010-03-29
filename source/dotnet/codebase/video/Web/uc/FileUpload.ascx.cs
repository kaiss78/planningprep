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
using App.Domain;
using App.Data;
using System.IO;
using App.Util;
using System.Collections.Generic;
using System.Text;

public partial class uc_FileUpload : System.Web.UI.UserControl
{
    // public attributes for the user control                 
    public string uploadText = "Upload file:";
    public string saveText = "Save as:";
    public string statusText = "Status:";
    public string submitText = "Upload File";

    private void Page_Load(object o, EventArgs e)
    {

        // move attributes into the form
        upSpan.InnerText = uploadText;
        statusSpan.InnerText = statusText;
        uploadBtn.Value = submitText;
    }

    protected void uploadBtn_Click(object o, EventArgs e)
    {


        // try save the file to the web server
        if (filename.PostedFile != null)
        {
            string sPath = AppUtil.GetUploadFolderForExel();
            if (!Directory.Exists(sPath))
            {
                Directory.CreateDirectory(sPath);
            }
            //build file info for display
            string sFileInfo =
                "<br>FileName: " +
                filename.PostedFile.FileName; 

            try
            {
                filename.PostedFile.SaveAs(System.IO.Path.Combine(sPath, Path.GetFileName(filename.PostedFile.FileName)));


                ChapterDefinitionFile file = ChapterFileManager.Instance.GetByFileName(Path.GetFileName(filename.PostedFile.FileName));
                if (file == null)
                {
                    file = new ChapterDefinitionFile();
                    file.FileName = Path.GetFileName(filename.PostedFile.FileName);
                }

                ChapterFileManager.Instance.Save(file);

                string filePath = Path.Combine(AppUtil.GetUploadFolderForExel(), file.FileName);
                string xmlDir = AppUtil.GetUploadFolderForXml();

                List<VideoSectionItem> videoSectionItems = ExelHelper.Instance.GetDataFromExcel(filePath);
                int levelCount = ExelHelper.Instance.GetLevelCount(videoSectionItems);
                List<VideoSectionItem> items = DataParser.Instance.GetHirararchialVideoSectionItems(videoSectionItems, xmlDir, levelCount, file.FileName);

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
                DeleteExistingFiles(fileNameWithoutExtension);
                XmlHelper.Instance.WriteXmlsForItems(fileNameWithoutExtension, fileNameWithoutExtension, items, 0);

                status.InnerHtml = "File uploaded successfully.";
                hplViewChapters.Visible = true;
                hplViewChapters.NavigateUrl = "~/pages/public/ViewChapters.aspx?FileID=" + file.Id;
            }
            catch (Exception exc)
            {
                status.InnerHtml = "Error saving file.";
            }
        }
    }


    private void DeleteExistingFiles(string filename)
    {
        try
        {
            string dir = Path.Combine(AppUtil.GetUploadFolderForXml(), filename);
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
        }
        catch (Exception ex)
        {

        }
    }
}
