<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuestionDetails.ascx.cs" Inherits="UserControls_QuestionDetails" %>
<%@ Register src="~/UserControls/Chart.ascx" tagname="Chart" tagprefix="uc1" %>
<%@ Register src="~/UserControls/RateQuestion.ascx" tagname="Rate" tagprefix="uc1" %>
<%@ Register src="~/UserControls/Commenting.ascx" tagname="Commenting" tagprefix="UC" %>
 <style type="text/css">
        <!--
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
        	width:50%;
        }        
        .chart
        {
        	
        }
        .option
        {
            margin-top: 5px;
            margin-bottom: 5px;
        }        
        .right
        {
        	color:Green;
        	font-size:11pt;
        	margin-bottom:20px;
        	font-weight:bold;
        }        
        .wrong
        {
        	color:Red;
        	font-size:11pt;
        	margin-bottom:20px;
        	font-weight:bold;
        }
        -->
        </style>
        <div class="contentheading">
    Question Details
    </div>
    <div class="floatleft QuestionDetails">
    <div id="divQuestion" runat="server">
        <div id="QuestionTitle">
            <asp:Label ID="lblQuestionTitle" runat="server" Text=""></asp:Label>
        </div>
        <div id="Options">
            <div class="option">
                <strong>A.</strong><asp:Label ID="lblA" runat="server" /></div>
            <div class="option">
                <strong>B.</strong><asp:Label ID="lblB" runat="server" /></div>
            <div class="option">
                <strong>C.</strong><asp:Label ID="lblC" runat="server" /></div>
            <div class="option">
                <strong>D.</strong><asp:Label ID="lblD" runat="server" /></div>
        </div>
    </div>
    <div id="divResult" runat="server">
        <div style="margin-bottom:10px">
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblQuestion" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblResultDetails" runat="server" Text=""></asp:Label></div>
    </div>
    <p id="QuestionDetails">
        <asp:Label ID="lblQuestionDetails" runat="server" Text=""></asp:Label>
    </p>
    
    <div>
        <asp:Repeater ID="rptQuestionLinks" runat="server" onitemdatabound="rptQuestionLinks_ItemDataBound">
        <ItemTemplate>
        <div>
            <asp:HyperLink ID="hlinkQuestionLink" runat="server" Text="" Target="_blank"></asp:HyperLink>
          <br />
            <asp:Label ID="lblQuestionLinkDescription" runat="server" Text=""></asp:Label>
        </div>
        <br />
        </ItemTemplate>
        </asp:Repeater>
    </div>
    </div>
    <div class="floatleft chart">
        <uc1:Chart ID="chartForQuestion" runat="server" />
    </div>
    <div class="clearboth"></div>
    <div>
        <uc1:Rate ID="rateQuestion" runat="server" />
    </div>
    <div runat="server" id="divNextQuestion">
        <div>
            <asp:HyperLink ID="hlinkNextQuestion" runat="server">Next Question</asp:HyperLink>
        </div>
    </div>
    
    <div>
        <UC:Commenting ID="ucCommenting" runat="server" Visible="false" />
    </div>