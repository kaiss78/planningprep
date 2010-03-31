using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Util;
using App.Data;
using App.Domain;

public partial class ViewChapters : App.Util.PagePage
{
    int ExelFileID;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Medstudy - Video list");
        ExelFileID = AppUtil.GetRequestParamValueInInt(AppConstants.UrlParams.EXEL_FILE_ID);
        chapters.ExelFileId = ExelFileID;
        if (!IsPostBack)
        {
            TrackViewInfo(chapters.ExelFileId);
        }
    }

    private void TrackViewInfo(long fileID)
    {
        ContentFileManager fileManager = new ContentFileManager();
        ContentFile file = fileManager.GetByID(fileID);
        if (file != null && SessionCache.CurrentUser != null)
        {
            FileTracking tracking = new FileTracking();
            tracking.UserID = SessionCache.CurrentUser.UserID;
            tracking.UserIP = AppUtil.GetRemoteIPAddress();
            tracking.FileID = fileID;
            tracking.IsViewed = true;
            tracking.IsDownloaded = false;

            FileTrackingManager manager = new FileTrackingManager();
            manager.Save(tracking);
        }
    }
}
