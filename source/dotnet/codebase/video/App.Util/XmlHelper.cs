using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Excel;
using System.IO;
using System.Xml;
using System.Web;

namespace App.Util
{
    public class XmlHelper
    {
        private StringWriter _StringWriter = null;
        private XmlTextWriter _XmlWriter = null;

        public XmlHelper()
        {


        }

        public static XmlHelper Instance
        {
            get
            {
                return new XmlHelper();
            }
        }

        private string GetDurationInSeconds(string strDurationInMinutes)
        {
            float duractionInMinutes = float.Parse(strDurationInMinutes);
            float seconds = duractionInMinutes * 60;
            return seconds.ToString();
        }

        private  string GetStartPoint(string startPointInSeconds)
        {
            int totalSeconds = Convert.ToInt32(startPointInSeconds);
            
            int minutesAfterSeconds = totalSeconds / 60;
            int secondsAfterMinutes = totalSeconds % 60;

            string strMinutes = minutesAfterSeconds < 10 ? string.Format("0{0}", minutesAfterSeconds) : minutesAfterSeconds.ToString();
            string strSeconds = secondsAfterMinutes < 10 ? string.Format("0{0}", secondsAfterMinutes) : secondsAfterMinutes.ToString();
            return string.Format("{0}:{1}", strMinutes, strSeconds);
        }

        private void CreateItemNode(VideoSectionItem item)
        {
            _XmlWriter.WriteRaw(String.Format(@"<item>
			            <title>{0}</title>
			            <media:content url='{1}' type='{2}' start='{3}' />
			            <description>{4}</description>
			            <link>{5}/</link>
		            </item>", AppUtil.FilterChapterName(item.Chapter), GetVideoUrl(item.FileName)
                                , item.FileType, GetStartPoint(item.StartTime)
                                //, GetDurationInSeconds(item.Duration) 
                                , AppUtil.Encode(item.Description), item.Link));
        }

        private String GetVideoUrl(string fileName)
        {
            return String.Format("{0}", fileName);
        }

        private String GetThumbNailUrl(String fileName)
        {
            return String.Format("{0}/{1}", ConfigReader.ThumbnailUrl, fileName);
        }

        private String SaveXml(String xmlContent, string upperLevelChapterName, int level, string xmlDir)
        {
            //xmlDir = Path.Combine(xmlDir, Path.GetFileNameWithoutExtension((string)HttpContext.Current.Session["CURRENT_FILE"]));

            String fileName = string.Empty;
            Directory.CreateDirectory(xmlDir);
            try
            {
                fileName = String.Format("{0}.xml", upperLevelChapterName.Trim());
                string xmlFileName = Path.Combine(xmlDir, AppUtil.GetFilteredDiskFileName(fileName));
                File.AppendAllText(xmlFileName, xmlContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fileName;
        }

        private String SaveXml(String xmlContent, VideoSectionItem item, string xmlDir)
        {
            //xmlDir = Path.Combine(xmlDir, Path.GetFileNameWithoutExtension((string)HttpContext.Current.Session["CURRENT_FILE"]));

            String fileName = string.Empty;
            Directory.CreateDirectory(xmlDir);
            try
            {
                
                fileName = String.Format("{0}.xml", AppUtil.GetFilteredDiskFileName(item.Chapter));
                string xmlFileName = Path.Combine(xmlDir, AppUtil.GetFilteredDiskFileName(fileName));
                File.AppendAllText(xmlFileName, xmlContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return fileName;
        }

       
             

        public void WriteXmlsForItems(string uppderLevelChapterName, string rootFolderName, List<VideoSectionItem> items, int level)
        {
            WriteXml(uppderLevelChapterName, rootFolderName, items, level);
            foreach (VideoSectionItem item in items)
            {
                if (item.ChildrenItems == null || item.ChildrenItems.Count == 0)
                {
                    WriteXml(uppderLevelChapterName, rootFolderName, item, level);
                }
            }
            foreach (VideoSectionItem item in items)
            {
                if (item.ChildrenItems != null)
                {
                    WriteXmlsForItems(item.Chapter, rootFolderName, item.ChildrenItems, level);
                }
            }
        }

        private void WriteXml(string upperLevelChapterName, string rootFolderName, List<VideoSectionItem> videoSectionItems, int level)
        {
            string xmlDir = Path.Combine(AppUtil.GetUploadFolderForXml(), rootFolderName);
            //GenerateXmlfileForItems(items, level, uppderLevelChapterName, dir);

            if (videoSectionItems != null && videoSectionItems.Count > 0)
            {
                _StringWriter = new StringWriter();
                _XmlWriter = new XmlTextWriter(_StringWriter);
                _XmlWriter.Formatting = Formatting.Indented;

                _XmlWriter.WriteRaw("<rss version='2.0' xmlns:media='http://search.yahoo.com/mrss/'>");
                _XmlWriter.WriteRaw("<channel>");
                ///TODO: For now title is hard coded. It should be replaced.
                _XmlWriter.WriteRaw("<title>Test playlist with differents video</title>");

                foreach (VideoSectionItem item in videoSectionItems)
                {
                    CreateItemNode(item);
                }

                _XmlWriter.WriteRaw("</channel>");
                _XmlWriter.WriteRaw("</rss>");
                _XmlWriter.Flush();

                _StringWriter.Flush();
                String xmlFileName = SaveXml(_StringWriter.ToString(), upperLevelChapterName, level, xmlDir);


                _XmlWriter.Close();
            }
        }

        private void WriteXml(string upperLevelChapterName, string rootFolderName, VideoSectionItem videoSectionItem, int level)
        {
            string xmlDir = Path.Combine(AppUtil.GetUploadFolderForXml(), rootFolderName);
            //GenerateXmlfileForItem(item, level, uppderLevelChapterName, dir);

            _StringWriter = new StringWriter();
            _XmlWriter = new XmlTextWriter(_StringWriter);
            _XmlWriter.Formatting = Formatting.Indented;

            _XmlWriter.WriteRaw("<rss version='2.0' xmlns:media='http://search.yahoo.com/mrss/'>");
            _XmlWriter.WriteRaw("<channel>");
            ///TODO: For now title is hard coded. It should be replaced.
            _XmlWriter.WriteRaw("<title>Test playlist with differents video</title>");


            CreateItemNode(videoSectionItem);


            _XmlWriter.WriteRaw("</channel>");
            _XmlWriter.WriteRaw("</rss>");
            _XmlWriter.Flush();

            _StringWriter.Flush();
            String xmlFileName = SaveXml(_StringWriter.ToString(), videoSectionItem, xmlDir);


            _XmlWriter.Close();
        }

        public void GenerateXmlfileForItem(VideoSectionItem videoSectionItem, int level, string upperLevelChapterName, string xmlDir)
        {
            
                
            
            ///TODO: Save Video File Information to the Database.
        }


        public void GenerateXmlfileForItems(List<VideoSectionItem> videoSectionItems, int level, string upperLevelChapterName, string xmlDir)
        {
            
            ///TODO: Save Video File Information to the Database.
        }

    }
}
