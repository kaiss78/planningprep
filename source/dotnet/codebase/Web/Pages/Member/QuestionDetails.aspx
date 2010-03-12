<%@ Page Language="C#" MasterPageFile="~/Pages/Member/MasterPageMember.master" AutoEventWireup="true"
    CodeFile="QuestionDetails.aspx.cs" Inherits="Pages_Member_QuestionDetails" Title="Untitled Page" %>

<%@ Register src="../../UserControls/Chart.ascx" tagname="Chart" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
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
</asp:Content>
