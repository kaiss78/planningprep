using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Excel;
using System.IO;
using System.Xml;

namespace App.Util
{
    public class ExelHelper
    {

        public static ExelHelper Instance
        {
            get
            {
                return new ExelHelper();
            }
        }

        public List<VideoSectionItem> GetDataFromExcel(String filePath)
        {
            IExcelDataReader excelReader = null;
            DataTable result = new DataTable("Videos");
            FileStream stream = null;
            try
            {
                stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                if (String.Compare(Path.GetExtension(filePath), ".xls", true) == 0)
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                else if (String.Compare(Path.GetExtension(filePath), ".xlsx", true) == 0)
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                if (excelReader != null)
                { 
                    excelReader.IsFirstRowAsColumnNames = true;
                    result = excelReader.AsDataSet().Tables[0];
                }
            }
            catch (Exception ex)
            {
                //log.Error(String.Format("Error Reading Excel File. Name: {0}. Error Message: {1} ", filePath, ex.Message));
            }
            finally
            {
                if (excelReader != null && !excelReader.IsClosed)
                    excelReader.Close();
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return ConvertToVideoSectionItemList(result);
        }

        private List<VideoSectionItem> ConvertToVideoSectionItemList(DataTable dataTable)
        {
            List<VideoSectionItem> videoSectionItems = new List<VideoSectionItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                VideoSectionItem item = new VideoSectionItem();

                item.Number = Convert.ToInt32(dr[AppConstants.ExcelColumns.NUMBER]);

                item.FileName = dr[AppConstants.ExcelColumns.FILE_NAME].ToString();
                item.Chapter = dr[AppConstants.ExcelColumns.CHAPTER_NAME].ToString();
                DateTime startTime = Convert.ToDateTime(dr[AppConstants.ExcelColumns.START_POINT]);
                
                item.StartTime = startTime.Second.ToString();
                item.Duration = dr[AppConstants.ExcelColumns.DURATION].ToString();
                item.ThumbNail = dr[AppConstants.ExcelColumns.THUMBNAIL].ToString();
                item.FileType = dr[AppConstants.ExcelColumns.VIDEO_TYPE].ToString();
                item.Description = dr[AppConstants.ExcelColumns.DESCRIPTION].ToString();
                item.Link = dr[AppConstants.ExcelColumns.LINK].ToString();

                videoSectionItems.Add(item);
            }

            return videoSectionItems;
        }

        public int GetLevelCount(List<VideoSectionItem> videoSectionItems)
        {
            int levelCount = 0;

            foreach(VideoSectionItem item in videoSectionItems)
            {
                string chapter = item.Chapter.Trim();
                int lastIndex = chapter.LastIndexOf("-");
                int previousIndex = lastIndex - 1;
                if(previousIndex < 0)
                {
                    if(lastIndex + 1 > levelCount)
                    {
                        levelCount = lastIndex + 1;
                    }
                }
                else 
                {
                    if(chapter[previousIndex] == '-')
                    {
                        if (lastIndex + 1 > levelCount)
                        {
                            levelCount = lastIndex + 1;
                        }
                    }
                }
                
            }

            return levelCount;
        }

    }

   
}
