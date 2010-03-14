<%@ Page Language="C#" MasterPageFile="~/Pages/Member/MasterPageMember.master" AutoEventWireup="true" CodeFile="AnswerQuestion.aspx.cs" Inherits="Pages_Member_AnswerQuestion" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">

    <script language="JavaScript">

<!--
//TIMER
// please keep these lines on when you copy the source
// made by: Nicolas - http://www.javascript-page.com
$(function(){
  Start();
});

var timerID = 0;
var tStart  = null;

function UpdateTimer() {
  if(timerID) {
     clearTimeout(timerID);
     clockID  = 0;
  }

  if(!tStart)
     tStart   = new Date();

  var   tDate = new Date();
  var   tDiff = tDate.getTime() - tStart.getTime();

  tDate.setTime(tDiff);

  document.getElementById("<%=txtTime.ClientID %>").value = "" 
                                  + ((tDate.getMinutes() < 10) ? "0" : "") + tDate.getMinutes() + ":" 
                                  + ((tDate.getSeconds() < 10) ? "0" : "") + tDate.getSeconds();
  
  timerID = setTimeout("UpdateTimer()", 1000);
}

function Start() {
  tStart   = new Date();
  document.getElementById("<%=txtTime.ClientID %>").value = "00:00";
  timerID  = setTimeout("UpdateTimer()", 1000);
}

function Stop() {
  if(timerID) {
     clearTimeout(timerID);
     timerID  = 0;
  }

  tStart = null;
}

function Reset() {
  tStart = null;

  document.question.theTime.value = "00:00";
}

//-->
    </script>

    <style type="text/css">
        <!
        #Options
        {
            margin-top: 20px;
        }
        #QuestionTitle
        {
            font-weight: bold;
            color: Green;
            margin-bottom: 20px;
        }
        #QuestionDetails
        {
            margin-top: 20px;
        }
        .QuestionDetails
        {
            width: 70%;
        }
        .timer
        {
            width: 30%;
            float: left;
        }
        .option
        {
            margin-top: 5px;
            margin-bottom: 5px;
        }
        -- ></style>
    <div class="floatleft QuestionDetails">
        <div id="QuestionTitle">
            <asp:Label ID="lblQuestionTitle" runat="server" Text=""></asp:Label>
        </div>
        <div id="Options">
            <div class="option">
                <strong>A.</strong><asp:RadioButton GroupName="question" ID="rdoA" runat="server" /></div>
            <div class="option">
                <strong>B.</strong><asp:RadioButton GroupName="question" ID="rdoB" runat="server" /></div>
            <div class="option">
                <strong>C.</strong><asp:RadioButton GroupName="question" ID="rdoC" runat="server" /></div>
            <div class="option">
                <strong>D.</strong><asp:RadioButton GroupName="question" ID="rdoD" runat="server" /></div>
        </div>
    </div>
    <div class="timer">
        <asp:TextBox ID="txtTime" Width="50px" runat="server"></asp:TextBox>
        <br>
        <input type="button" name="start" value="Restart" onclick="Start()">
        <input type="button" name="stop" value="Stop" onclick="Stop()">
        <p>
            The timer is provided to see how long you are spending on each question. The AICP
            exam requires you to answer 150 questions in 3 hours, or 1 question every 72 seconds
            (1:12).
        </p>
    </div>
    <div class="clearboth">
    </div>
    
    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" />
        <input type="reset" value="Clear" />
    </div>
</asp:Content>
