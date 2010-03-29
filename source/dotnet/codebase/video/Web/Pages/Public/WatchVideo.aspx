<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WatchVideo.aspx.cs" Inherits="WatchVideo" %>

<%@ Register src="~/uc/WatchVideo.ascx" tagname="WatchVideo" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
        <script type='text/javascript' src='http://ec.europa.eu/wel/players/jwflvplayer/swfobject.js'></script>
<link type="text/css" href="../../css/style.css" rel="Stylesheet" />
    <script type='text/javascript' src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>

</head>
<body style="background-color:#ffffff">
    <form id="form1" runat="server">
    <div style="padding:20px;">
    <uc1:WatchVideo ID="watchVideo" runat="server" />
    </div>
    </form>
</body>
</html>
