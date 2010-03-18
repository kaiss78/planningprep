<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FAQList.aspx.cs" Inherits="Pages_Admin_FAQList" Title="Untitled Page" %>

<%@ Register src="/UserControls/PaginatedQuestions.ascx" tagname="PaginatedQuestions" tagprefix="UC" %>
<%@ Register Src="/UserControls/Pager.ascx" TagName="Pager" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="floatright">
        <asp:HyperLink ID="hplAddNewFAQ" runat="server">Add New FAQ Question</asp:HyperLink> &nbsp;
        <asp:HyperLink ID="hplManageFAQCategory" runat="server">Manage Category</asp:HyperLink>
    </div>
    <div class="clearfloating"></div>
    
    <div class="contentheading">List of FAQ Questions</div>
    
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
                        <asp:Label ID="lblQuestionTitle" runat="server" Text="Question"></asp:Label>
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
                    <asp:HyperLink ID="hplQuestion" runat="server">Edit</asp:HyperLink>
                </td>
                <td>
                    <asp:Label ID="lblModified" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="EvenRowListing">
                <td>
                    <asp:HyperLink ID="hplQuestion" runat="server"></asp:HyperLink>
                </td>
                <td>
                    <asp:Label ID="lblModified" runat="server" Text=""></asp:Label>
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
        <UC:Pager ID="ucPager" runat="server" OnPageIndexChanged="ucPager_PageIndexChanged" />
    </div>
</asp:Content>

