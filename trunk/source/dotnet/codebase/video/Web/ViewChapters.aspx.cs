using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Util;

public partial class ViewChapters : System.Web.UI.Page
{
    int ExelFileID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ExelFileID = AppUtil.GetRequestParamValueInInt(AppConstants.UrlParams.EXEL_FILE_ID);
        chapters.ExelFileId = ExelFileID;
    }
}
