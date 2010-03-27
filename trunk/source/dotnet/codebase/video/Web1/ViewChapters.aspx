<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewChapters.aspx.cs" Inherits="ViewChapters" %>

<%@ Register src="uc/Chapters.ascx" tagname="Chapters" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="css/style.css" type="text/css" />
    <script type='text/javascript' src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script language="javascript">
    $(function(){
        // Document is ready
        $(".expandCollapseDiv").click(function () { 
            var wrapperId = $(this).attr("wrapperId");
            
            if($(this).text() == "+")
            {
                $("div[childrenId=" + wrapperId +"]").show(100);
                $(this).text("-");
            }
            else
            {
                $("div[childrenId=" + wrapperId +"]").hide(100);               
                $(this).text("+");
            }
            
        });

    });
    
    function runVideo(xmlUrl)
    {
        window.open(xmlUrl);
    }
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <uc1:Chapters ID="chapters" runat="server" />
    </form>
</body>
</html>
