<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaginatedQuestions.ascx.cs" Inherits="UserControls_PaginatedQuestions" %>
<%@ Register src="~/UserControls/Pager.ascx" tagname="Pager" tagprefix="Pager" %>
    <div class="contentheading" style="float:left;">Question List</div>
    
    <table cellpadding="3" cellspacing="0" width="100%">
        <colgroup>
            <col style="width:75%;" />
            <col style="width:15%;" />
            <col style="width:10%;" />
        </colgroup>
        <tr>
            <td class="listtitle">
                <asp:Label ID="lblQuestionTitle" runat="server" Text="Question Title"></asp:Label></td>
            <td class="listtitle">
                <asp:Label ID="lblLastModified" runat="server" Text="Last Modified"></asp:Label></td>
            <td class="listtitle">
                <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label></td>
        </tr>    
        <asp:Repeater ID="rptQuestionList" runat="server" 
            onitemdatabound="rptQuestionList_ItemDataBound">
            <ItemTemplate>
                <tr class="OddRowListing">
                    <td><asp:Label ID="lblQuestion" runat="server" Text=''></asp:Label><asp:HyperLink ID="hlinkQuestion" runat="server"></asp:HyperLink></td>
                    <td><asp:Label ID="lblExplanation" runat="server" Text=""></asp:Label></td>
                    <td><asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="EvenRowListing">
                    <td><asp:Label ID="lblQuestion" runat="server" Text=''></asp:Label><asp:HyperLink ID="hlinkQuestion" runat="server"></asp:HyperLink></td>
                    <td><asp:Label ID="lblExplanation" runat="server" Text=""></asp:Label></td>
                    <td><asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink></td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </table>
    <div style="margin-top:20px;">
        <Pager:Pager ID="ucPager" runat="server" OnPageIndexChanged="ucPager_PageIndexChanged" />
    </div>
