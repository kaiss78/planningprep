<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaginatedUsers.ascx.cs"
    Inherits="UserControls_PaginatedUsers" %>
<%@ Register Src="~/UserControls/Pager.ascx" TagName="Pager" TagPrefix="Pager" %>
<div class="contentheading" style="float: left;">
    User List</div>
<div>
    <asp:Label ID="lblNoUserFoundMessage" Visible="false" runat="server" Text="No User found."></asp:Label>
</div>
<asp:Repeater ID="rptUserList" runat="server" OnItemDataBound="rptUserList_ItemDataBound">
    <HeaderTemplate>
        <table cellpadding="3" cellspacing="0" width="100%">
            <colgroup>
                <col style="width: 75%;" />
                <col style="width: 15%;" />
                <col style="width: 10%;" />
            </colgroup>
            <tr>
                <td class="listName">
                    <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="listName">
                    <asp:Label ID="lblLastModified" runat="server" Text="Last Modified"></asp:Label>
                </td>
                <td class="listName">
                    <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="OddRowListing">
            <td>
                <asp:Label ID="lblUser" runat="server" Text=''></asp:Label><asp:HyperLink ID="hlinkUser"
                    runat="server"></asp:HyperLink>
            </td>
            <td>
                <asp:Label ID="lbLastModifiedDate" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink>
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="EvenRowListing">
            <td>
                <asp:Label ID="lblUser" runat="server" Text=''></asp:Label><asp:HyperLink ID="hlinkUser"
                    runat="server"></asp:HyperLink>
            </td>
            <td>
                <asp:Label ID="lbLastModifiedDate" runat="server" Text=""></asp:Label>
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
