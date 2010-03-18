<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FaqCategoryList.aspx.cs" Inherits="Pages_Admin_FaqCategoryList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="floatright">
        <asp:HyperLink ID="hplAddNewFAQCategory" runat="server">Add New FAQ Category</asp:HyperLink>
    </div>
    <div class="clearfloating"></div>
    
    <div class="contentheading">List of FAQ Categories</div>
    
    
    <div>
        <asp:Label ID="lblNoQuestionFoundMessage" Visible="false" runat="server" Text="No Question found."></asp:Label>
    </div>
    <asp:Repeater ID="rptCategoryList" runat="server" OnItemDataBound="rptCategoryList_ItemDataBound">
        <HeaderTemplate>
            <table cellpadding="3" cellspacing="0" width="100%">
                <colgroup>
                    <col style="width: 45%;" />
                    <col style="width: 20%;" />
                    <col style="width: 20%;" />
                    <col style="width: 15%;" />
                </colgroup>
                <tr>
                    <td class="listtitle">
                        <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                    </td>
                    <td class="listtitle">
                        <asp:Label ID="lblLastModified" runat="server" Text="Last Modified"></asp:Label>
                    </td>
                    <td class="listtitle">
                        <asp:Label ID="lblEnteredBy" runat="server" Text="Modified By"></asp:Label>
                    </td>
                    <td class="listtitle">
                        <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="OddRowListing">
                <td>
                    <asp:HyperLink ID="hplCategory" runat="server"></asp:HyperLink>
                </td>
                <td>
                    <asp:Label ID="lblModified" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEnteredBy" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="EvenRowListing">
                <td>
                    <asp:HyperLink ID="hplCategory" runat="server"></asp:HyperLink>
                </td>
                <td>
                    <asp:Label ID="lblModified" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEnteredBy" runat="server" Text=""></asp:Label>
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

</asp:Content>

