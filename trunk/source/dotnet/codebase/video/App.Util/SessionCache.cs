
#region References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Util;
using App.Data;

#endregion

#region Class

/// <summary>
/// Acts as a facade to cached data stored at the Session scope
/// </summary>
public class SessionCache
{
    #region Constructor

    public SessionCache()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Instance

    /// <summary>
    /// SessionCache instance property
    /// </summary>

    //private static SessionCache _instance = new SessionCache(); 
    public static SessionCache Instance
    {
        get
        {
            return new SessionCache();
        }
    }

    #endregion

    #region Properties
    

    /// <summary>
    /// Current Video section items
    /// </summary>
    public static List<VideoSectionItem> VideoSectionItems
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            if (HttpContext.Current.Session["VIDEO_SECTION_ITEMS"] == null) return null;
            return HttpContext.Current.Session["VIDEO_SECTION_ITEMS"] as List<VideoSectionItem>;
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["VIDEO_SECTION_ITEMS"] = value;
            }
        }
    }

    /// <summary>
    /// Current Chapter definition file
    /// </summary>
    public static ChapterDefinitionFile CurrentFile
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            if (HttpContext.Current.Session["CHAPTER_FILE"] == null) return null;
            return HttpContext.Current.Session["CHAPTER_FILE"] as ChapterDefinitionFile;
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CHAPTER_FILE"] = value;
            }
        }
    }
    public static SiteUser CurrentUser
    {
        get
        {
            if (HttpContext.Current.Session == null)
            {
                return null;
            }
            if (HttpContext.Current.Session["CURRENT_USER"] == null) return null;
            return HttpContext.Current.Session["CURRENT_USER"] as SiteUser;
        }
        set
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session["CURRENT_USER"] = value;
            }
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Clears the session.
    /// </summary>
    public static void ClearSession()
    {
        HttpContext.Current.Session.Clear();
    }

    public static VideoSectionItem GetVideoSectionItemByNumber(int Number)
    {
        foreach(VideoSectionItem item in VideoSectionItems)
        {
            if(item.Number == Number)
            {
                return item;
            }
        }
        return null;
    }

    #endregion
}

#endregion
