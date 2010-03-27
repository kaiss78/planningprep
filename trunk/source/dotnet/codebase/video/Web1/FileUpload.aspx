<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="FileUpload.aspx.cs" Inherits="_FileUpload" %>
<%@ register tagprefix="era" tagname="upload" src="~/uc/FileUpload.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<era:upload id="myControl" uploadText="Select File:" runat="server"/>
    </div>
    </form>
</body>
</html>
