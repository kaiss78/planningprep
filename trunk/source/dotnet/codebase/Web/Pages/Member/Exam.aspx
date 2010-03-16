﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Exam.aspx.cs" Inherits="Pages_Exam" %>

<%@ OutputCache Location="None" NoStore="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        table td
        {
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <!-- COUNTDOWN TIMER -->
    <!-- This goes in the HEAD of the html file -->

    <script language="JavaScript" type="text/javascript">
 
      $(document).ready(function() {
 
          // put all your jQuery goodness in here.
           $("#<%=chkBookmark.ClientID %>").click(function() {
            var checkbox = document.getElementById("<%=chkBookmark.ClientID%>");
            if(checkbox.checked)
            {
               $("input[type='radio']").each(function(){
                $(this).checked = false;  
                });

            }          
             
            });
           

           
      });


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
    
    location.href = "ExamResult.aspx?Action=Finish&ExamSessionID=" + <%=ExamSessionID %>
    
}
}
window.onload = countDown;
// -->
    </script>

    <style type="text/css">
        .timeClass
        {
            font-family: arial,verdana,helvetica,sans-serif;
            font-weight: normal;
            font-size: 10pt;
        }
        .divCenter
        {
            margin: 0px auto;
            width: 600px;
            margin-top: 20px;
        }
        .timerDiv
        {
            margin-bottom: 20px;
        }
        .navigationDiv
        {
            width: 600px;
            margin-top: 20px;
        }
        #Options
        {
            margin-top: 20px;
        }
        #QuestionTitle
        {
            font-weight: bold;
            color: Green;
        }
        .timeClass
        {
            font-weight: bold;
        }
        .bookmarkQuestion
        {
            margin-left: 20px;
        }
    </style>
    <div class="divCenter">
        <div>
            <asp:Label ID="lblBookedMarkedQuestions" runat="server" Visible="false" Font-Bold="true"
                ForeColor="Red" Text="Bookedmarked Questions"></asp:Label>
        </div>
        <div class="timerDiv">
            <!-- This goes into the BODY of the file -->
            Time Remaining : <span id="theTime" class="timeClass"></span>(Question <strong>
                <%=GetCurrentQuestionNo()%></strong> of <strong>
                    <%=GetCurrentQuestionCount()%></strong>)<span class="bookmarkQuestion"><asp:CheckBox
                        ID="chkBookmark" runat="server" Text="Bookmark this question." /></span>
        </div>
        <div style="margin-bottom: 10px">
            <div style="height: 10px; width: 100%; background-color: LightGrey">
                <div style="height: 10px; width: <%=Progress%>%; background-color: Green">
                </div>
            </div>
        </div>
        <div>
            <div id="QuestionTitle">
                <asp:Label ID="lblQuestionTitle" runat="server" Text=""></asp:Label>
            </div>
            <div id="Options">
                <div>
                    <strong>A.</strong><asp:RadioButton GroupName="question" ID="rdoA" runat="server" /></div>
                <div>
                    <strong>B.</strong><asp:RadioButton GroupName="question" ID="rdoB" runat="server" /></div>
                <div>
                    <strong>C.</strong><asp:RadioButton GroupName="question" ID="rdoC" runat="server" /></div>
                <div>
                    <strong>D.</strong><asp:RadioButton GroupName="question" ID="rdoD" runat="server" /></div>
            </div>
        </div>
        <div class="navigationDiv">
            <span style="margin-right: 200px">
                <asp:LinkButton ID="lnkPrevious" runat="server" OnClick="lnkPrevious_Click">Previous</asp:LinkButton></span>
            <span>
                <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click">Next</asp:LinkButton></span>
        </div>
    </div>
</asp:Content>
