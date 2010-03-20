<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Admin_ManageUsers" Title="Untitled Page" %>

<%@ Register Src="~/UserControls/PaginatedUsers.ascx" TagName="PaginatedUsers" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/CSS/ModalPopup.css" rel="Stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">

    <div style="float:right;"><asp:HyperLink ID="hplAddNewUser" runat="server">Add New User</asp:HyperLink></div>
    <div class="clearfloating"></div>
    <UC:PaginatedUsers ID="PaginatedUsers1" ShowLastModifiedDate="true" ShowUserTitle="true" ShowDetailsLink="true" ShowEditLink="true" runat="server" />

</asp:Content>

