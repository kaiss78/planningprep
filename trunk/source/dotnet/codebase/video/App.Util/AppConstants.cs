using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for AppConstants
/// </summary>

namespace App.Util
{
    public class AppConstants
    {
        public class Directories
        {
            public const String EXCEL_INPUTS = "/InputExcel";
            public const String XML_LIBRARY = "/XmlLibrary";
        }
        public class ExcelColumns
        {
            public const String NUMBER = "number";
            public const String FILE_NAME = "fileName";
            public const String CHAPTER_NAME = "chapter";
            public const String START_POINT = "startTime";
            public const String DURATION = "duration";
            public const String VIDEO_TYPE = "fileType";
            public const String THUMBNAIL = "thumbNail";
            public const String DESCRIPTION = "description";
            public const String LINK = "link";
        }

        public class UrlParams
        {
            public const String EXEL_FILE_ID = "ExelId";
        }
    }
}
