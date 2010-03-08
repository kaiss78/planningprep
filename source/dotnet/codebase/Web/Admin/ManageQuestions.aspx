<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="ManageQuestions.aspx.cs" Inherits="Admin_ManageQuestions" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table cellpadding="3" cellspacing="0" width="100%">
        <colgroup>
            <col style="width:45%;" />
            <col style="width:45%;" />
            <col style="width:10%;" />
        </colgroup>
        <tr>
            <td>Question Title</td>
            <td>Explanation</td>
            <td>Edit</td>
        </tr>    
        <asp:Repeater ID="rptQuestionList" runat="server" 
            onitemdatabound="rptQuestionList_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                    <td><asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>

