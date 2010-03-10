<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Pages_Exam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" language="javascript" src="../../JavaScripts/jquery-1.3.2.min.js"></script>

    <!-- COUNTDOWN TIMER -->
    <!-- This goes in the HEAD of the html file -->

    <script language="JavaScript" type="text/javascript">

<!--
var sec = <%=Seconds %>   // set the seconds
var min = <%=Minutes %>   // set the minutes


function countDown() {
   sec--;
  if (sec == -01) {
   sec = 59;
   min = min - 1; }
  else {
   min = min; }

if (sec<=9) { sec = "0" + sec; }

  time = (min<=9 ? "0" + min : min) + " min and " + sec + " sec ";

if (document.getElementById) { document.getElementById('theTime').innerHTML = time; }

SD=window.setTimeout("countDown();", 1000);
if (min == '00' && sec == '00') 
{ 
    sec = "00"; 
    window.clearTimeout(SD); 
    
    location.href = "ExamResult.aspx?ExamSessionID=" + <%=ExamSessionID %>
    
}
}
window.onload = countDown;
// -->
    </script>

    <style type="text/css">
        <!
        -- .timeClass
        {
            font-family: arial,verdana,helvetica,sans-serif;
            font-weight: normal;
            font-size: 10pt;
        }
        .divCenter
        {
            margin: 0px auto;
            width: 600px;
            margin-top:100px;
        }
        
        .timerDiv
        {
            margin-bottom:30px;
        }
        
        .navigationDiv
        {
        	width:600px;
        	margin-top:20px;
        }
        
        -- ></style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divCenter">
        <div class="timerDiv">
            <!-- This goes into the BODY of the file -->
            <span id="theTime" class="timeClass"></span>
        </div>
        <div>
            <div id="QuestionTitle">
                <asp:Label ID="lblQuestionTitle" runat="server" Text=""></asp:Label>
            </div>
            <div id="Options">
                <div>
                    <asp:RadioButton GroupName="question" ID="rdoA" runat="server" /></div>
                <div>
                    <asp:RadioButton GroupName="question" ID="rdoB" runat="server" /></div>
                <div>
                    <asp:RadioButton GroupName="question" ID="rdoC" runat="server" /></div>
                <div>
                    <asp:RadioButton GroupName="question" ID="rdoD" runat="server" /></div>
            </div>
        </div>
        <div class="navigationDiv">
                <asp:LinkButton ID="lnkPrevious" runat="server" OnClick="lnkPrevious_Click">Previous</asp:LinkButton>
                <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click">Next</asp:LinkButton>
        </div>
    </div>
    </form>
</body>
</html>
