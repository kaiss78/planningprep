<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Admin_ManageUsers" Title="Untitled Page" %>

<%@ Register src="../../UserControls/PaginatedUsers.ascx" tagname="PaginatedUsers" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">

    <div style="float:right;"><asp:HyperLink ID="hplAddNewUser" runat="server">Add New User</asp:HyperLink></div>
    <div class="clearfloating"></div>
      <uc1:PaginatedUsers ID="PaginatedUsers1" ShowUserTitle="true" ShowDetailsLink="true" ShowEditLink="true" runat="server" />

</asp:Content>

