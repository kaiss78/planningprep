using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Util
{
    public class DataParser
    {
        public DataParser()
        {

        }

        public static DataParser Instance
        {
            get
            {
                return new DataParser();
            }
        }

        public List<VideoSectionItem> GetHirararchialVideoSectionItems(List<VideoSectionItem> videoSectionItems, string xmlDir, int levelCount, string ExelFileName)
        {
            List<VideoSectionItem> sectionItemsForLevel = null;

            sectionItemsForLevel = GetFirstLevelChildren(videoSectionItems, null, xmlDir, 0, ExelFileName);

            foreach (VideoSectionItem item in sectionItemsForLevel)
            {
                LoadChildrenForItem(item, levelCount, videoSectionItems);
            }

            return sectionItemsForLevel;
        }

        private void LoadChildrenForItem(VideoSectionItem item, int maxLevel, List<VideoSectionItem> itemList)
        {
            int itemLevel = getLevelForItem(item);
            if (itemLevel == maxLevel)
            {
                return;
            }
            else
            {
                item.ChildrenItems = PopulateSectionItemsForLevel(itemList, item);
                if (item.ChildrenItems != null)
                {
                    for (int i = 0; i < item.ChildrenItems.Count; i++)
                    {
                        VideoSectionItem childItem = item.ChildrenItems[i];
                        LoadChildrenForItem(childItem, maxLevel, itemList);
                    }
                }
            }

        }

        private int getLevelForItem(VideoSectionItem item)
        {
            int level = 0;
            string chapterName = item.Chapter.Trim();
            int i = 0;
            while (i < chapterName.Length)
            {
                if (chapterName[i] != '-')
                {
                    break;
                }
                level++;
                i++;
            }
            return level;
        }

        private List<VideoSectionItem> GetFirstLevelChildren(List<VideoSectionItem> videoSectionItems, List<VideoSectionItem> upperLevelItems, string xmlDir, int level, string ExelFileName)
        {
            string hyphenForLevel = string.Empty;
            for (int i = 0; i < level; i++)
            {
                hyphenForLevel += "-";
            }

            List<VideoSectionItem> sectionItemsForLevel = new List<VideoSectionItem>();

            if (hyphenForLevel.Length == 0)
            {
                foreach (VideoSectionItem item in videoSectionItems)
                {
                    if (!item.Chapter.Trim().StartsWith("-"))
                    {
                        sectionItemsForLevel.Add(item);
                    }
                }
            }
            return sectionItemsForLevel;
        }

        private List<VideoSectionItem> PopulateSectionItemsForLevel(List<VideoSectionItem> videoSectionItems, VideoSectionItem currentItem)
        {
            int level = getLevelForItem(currentItem);
            int childLevel = level + 1;

            string hyphenForLevel = string.Empty;
            for (int i = 0; i < childLevel; i++)
            {
                hyphenForLevel += "-";
            }

            List<VideoSectionItem> childItems = new List<VideoSectionItem>();

            for (int j = 0; j < videoSectionItems.Count; j++)
            {
                VideoSectionItem item = videoSectionItems[j];
                if (item.Number == currentItem.Number)
                {
                    childItems = new List<VideoSectionItem>();
                    for (j = j + 1; j < videoSectionItems.Count; j++)
                    {
                        item = videoSectionItems[j];
                        int levelForItem = getLevelForItem(item);

                        if (levelForItem == level)
                        {
                            currentItem.ChildrenItems = childItems;
                            break;
                        }

                        if (isChild(item, hyphenForLevel))
                        {
                            childItems.Add(item);
                        }
                    }

                }
            }

            return childItems;
        }

        private bool isChild(VideoSectionItem item, string hyphenForLevel)
        {
            if (item.Chapter.Trim().StartsWith(hyphenForLevel))
            {
                string chapterNameWithoutHyphen = item.Chapter.Trim().Substring(hyphenForLevel.Length);
                if (!chapterNameWithoutHyphen.Trim().StartsWith("-"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
