<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuestionDetails.ascx.cs" Inherits="UserControls_QuestionDetails" %>
<%@ Register src="~/UserControls/Chart.ascx" tagname="Chart" tagprefix="uc1" %>
<%@ Register src="~/UserControls/RateQuestion.ascx" tagname="Rate" tagprefix="uc1" %>
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
    <p id="QuestionDetails">
        <asp:Label ID="lblQuestionDetails" runat="server" Text=""></asp:Label>
    </p>
    <p>        
        More information on this topic can be found at these sites:
    </p>
    <div>
        <asp:Repeater ID="rptQuestionLinks" runat="server" 
            onitemdatabound="rptQuestionLinks_ItemDataBound">
        <ItemTemplate>
        <div>
            <asp:HyperLink ID="hlinkQuestionLink" runat="server" Text=""></asp:HyperLink>
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
        <p>
            Thanks for Rating This Question
        </p>
        <div>
        <asp:HyperLink ID="hlinkNextQuestion" runat="server">Next Question</asp:HyperLink>
        </div>
    </div>