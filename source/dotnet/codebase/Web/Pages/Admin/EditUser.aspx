<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Pages_Admin_EditUser" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/UserProfile.ascx" TagName="UserProfile" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <UC:UserProfile ID="ucUserProfile" IsEditMode="true" runat="server" />
</asp:Content>

