<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="Pages_Admin_UserDetails" Title="Untitled Page" %>
<%@ Register Src="~/UserControls/UserProfile.ascx" TagName="UserProfile" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <UC:UserProfile ID="ucUserProfile" IsEditMode="false" ShowInfoText="false" runat="server" />
</asp:Content>

