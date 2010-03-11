<%@ Page Language="C#" MasterPageFile="~/Pages/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="ManageQuestions.aspx.cs" Inherits="Admin_ManageQuestions" Title="Untitled Page" %>

<%@ Register src="~/UserControls/Pager.ascx" tagname="Pager" tagprefix="Pager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">

    <div class="contentheading" style="float:left;">Question List</div>

    <div style="float:right;"><asp:HyperLink ID="hplAddNewQuestion" runat="server">Add New Question</asp:HyperLink></div>
    <div class="clearfloating"></div>
    
    <table cellpadding="3" cellspacing="0" width="100%">
        <colgroup>
            <col style="width:75%;" />
            <col style="width:15%;" />
            <col style="width:10%;" />
        </colgroup>
        <tr>
            <td class="listtitle">Question Title</td>
            <td class="listtitle">Last Modified</td>
            <td class="listtitle">Edit</td>
        </tr>    
        <asp:Repeater ID="rptQuestionList" runat="server" 
            onitemdatabound="rptQuestionList_ItemDataBound">
            <ItemTemplate>
                <tr class="OddRowListing">
                    <td><asp:Label ID="lblQuestion" runat="server" Text=''></asp:Label></td>
                    <td><asp:Label ID="lblExplanation" runat="server" Text=""></asp:Label></td>
                    <td><asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="EvenRowListing">
                    <td><asp:Label ID="lblQuestion" runat="server" Text=''></asp:Label></td>
                    <td><asp:Label ID="lblExplanation" runat="server" Text=""></asp:Label></td>
                    <td><asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink></td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </table>
    <div style="margin-top:20px;">
        <Pager:Pager ID="ucPager" runat="server" OnPageIndexChanged="ucPager_PageIndexChanged" />
    </div>
</asp:Content>

