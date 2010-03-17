<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaginatedQuestions.ascx.cs"
    Inherits="UserControls_PaginatedQuestions" %>
<%@ Register Src="~/UserControls/Pager.ascx" TagName="Pager" TagPrefix="Pager" %>
<div class="contentheading">
    Question List</div>
<div>
    <asp:Label ID="lblNoQuestionFoundMessage" Visible="false" runat="server" Text="No Question found."></asp:Label>
</div>
<asp:Repeater ID="rptQuestionList" runat="server" OnItemDataBound="rptQuestionList_ItemDataBound">
    <HeaderTemplate>
        <table cellpadding="3" cellspacing="0" width="100%">
            <colgroup>
                <col style="width: 75%;" />
                <col style="width: 15%;" />
                <col style="width: 10%;" />
            </colgroup>
            <tr>
                <td class="listtitle">
                    <asp:Label ID="lblQuestionTitle" runat="server" Text="Question Title"></asp:Label>
                </td>
                <td class="listtitle">
                    <asp:Label ID="lblLastModified" runat="server" Text="Last Modified"></asp:Label>
                </td>
                <td class="listtitle">
                    <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="OddRowListing">
            <td>
                <asp:Label ID="lblQuestion" runat="server" Text=''></asp:Label><asp:HyperLink ID="hlinkQuestion"
                    runat="server"></asp:HyperLink>
            </td>
            <td>
                <asp:Label ID="lblExplanation" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink>
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="EvenRowListing">
            <td>
                <asp:Label ID="lblQuestion" runat="server" Text=''></asp:Label><asp:HyperLink ID="hlinkQuestion"
                    runat="server"></asp:HyperLink>
            </td>
            <td>
                <asp:Label ID="lblExplanation" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink>
            </td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<div style="margin-top: 20px;">
    <Pager:Pager ID="ucPager" runat="server" OnPageIndexChanged="ucPager_PageIndexChanged" />
</div>
