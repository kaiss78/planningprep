using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Util
{
    public class VideoSectionItem
    {
        public List<VideoSectionItem> ChildrenItems
        {
            get;
            set;
        }
        public int Number
        {
            get; set;
        }
        public string Chapter
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string FileName
        {
            get;
            set;
        }
        public string FileType
        {
            get;
            set;
        }
        public string StartTime
        {
            get;
            set;
        }
        public string Duration
        {
            get;
            set;
        }
        public string ThumbNail
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
        public string Link
        {
            get;
            set;
        }
    }
}
