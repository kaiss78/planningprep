<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Pages_Exam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/Styles.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="ExamDiv">
    <div id="CurrentQuestion">
        <div id="QuestionTitle">
            <asp:Label ID="lblQuestionTitle" runat="server" Text=""></asp:Label>
        </div>
        <div id="Options">
            <div><asp:RadioButton ID="rdoA" runat="server" /></div>
            <div><asp:RadioButton ID="rdoB" runat="server" /></div>
            <div><asp:RadioButton ID="rdoC" runat="server" /></div>
            <div><asp:RadioButton ID="rdoD" runat="server" /></div>
        </div>
    </div>
    <div>
        <div class="floatleft">
            <asp:HyperLink ID="hlinkPrevious" runat="server">Previous</asp:HyperLink></div>
        <div class="floatright">
            <asp:HyperLink ID="hlinkNext" runat="server">Next</asp:HyperLink></div>
    </div>
    </div>
    </form>
</body>
</html>
