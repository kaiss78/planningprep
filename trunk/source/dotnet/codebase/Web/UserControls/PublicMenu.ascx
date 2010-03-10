<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PublicMenu.ascx.cs" Inherits="UserControls_PublicMenu" %>

<div style="width:800px; margin-left:auto; margin-right:auto">
    <div class="menuitem"><a href="/Default.aspx" class="headermenu">Home</a></div>
    <div class="menuitem">About Us</div>
    <div class="menuitem"><a href="/Pages/Public/ContactUs.aspx" class="headermenu">Contant Us</a></div>
    <div class="menuitem">FAQ</div>
    <div class="menuitem"><a href="/Pages/Public/Register.aspx" class="headermenu">Join</a></div>
    <div class="menuitem"><asp:HyperLink ID="hplLogin" NavigateUrl="/Login.aspx" runat="server" CssClass="headermenu">Log In</asp:HyperLink></div>
    <div class="clearfloating"></div>
</div>