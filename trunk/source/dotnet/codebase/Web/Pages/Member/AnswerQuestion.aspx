<%@ Page Language="C#" MasterPageFile="~/Pages/Member/MasterPageMember.master" AutoEventWireup="true" CodeFile="AnswerQuestion.aspx.cs" Inherits="Pages_Member_AnswerQuestion" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
<script language="JavaScript">

<!--
//TIMER
// please keep these lines on when you copy the source
// made by: Nicolas - http://www.javascript-page.com

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

  document.question.theTime.value = "" 
                                  + ((tDate.getMinutes() < 10) ? "0" : "") + tDate.getMinutes() + ":" 
                                  + ((tDate.getSeconds() < 10) ? "0" : "") + tDate.getSeconds();
  
  timerID = setTimeout("UpdateTimer()", 1000);
}

function Start() {
  tStart   = new Date();

  document.question.theTime.value = "00:00";

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
        	margin-top:20px;
        }
        
        .QuestionDetails
        {
        	width:70%;
        }
        
        .chart
        {
        	margin-left:20px;
        }
        -- ></style>
    <div class="floatleft QuestionDetails">
    <div>
        <div id="QuestionTitle">
            
            <asp:Label ID="lblQuestionTitle" runat="server" Text=""></asp:Label>
        </div>
        <div id="Options">
            <div>
                <strong>A.</strong><asp:Label ID="lblA" runat="server" /></div>
            <div>
                <strong>B.</strong><asp:Label ID="lblB" runat="server" /></div>
            <div>
                <strong>C.</strong><asp:Label ID="lblC" runat="server" /></div>
            <div>
                <strong>D.</strong><asp:Label ID="lblD" runat="server" /></div>
        </div>
    </div>
</asp:Content>

