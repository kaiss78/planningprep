<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Pages_Exam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/Styles.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../JavaScripts/jquery-1.3.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="ExamDiv">
    <div id="CurrentQuestion">
        <div id="QuestionTitle">
            <asp:Label ID="lblQuestionTitle" runat="server" Text=""></asp:Label>
        </div>
        <div id="Options">
            <div><asp:RadioButton GroupName="question" ID="rdoA" runat="server" /></div>
            <div><asp:RadioButton GroupName="question" ID="rdoB" runat="server" />
            <div><asp:RadioButton GroupName="question" ID="rdoC" runat="server" /></div>
            <div><asp:RadioButton GroupName="question" ID="rdoD" runat="server" /></div>
        </div>
    </div>
    <div>
        <div class="floatleft">
            <asp:LinkButton ID="lnkPrevious" runat="server" onclick="lnkPrevious_Click">Previous</asp:LinkButton>
        <div class="floatright">
        <asp:LinkButton ID="lnkNext" runat="server" onclick="lnkNext_Click">Next</asp:LinkButton>
            </div>
    </div>
    </div>
    </form>
</body>
</html>
