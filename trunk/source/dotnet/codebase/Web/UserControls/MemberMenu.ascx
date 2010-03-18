﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberMenu.ascx.cs" Inherits="UserControls_MemberMenu" %>

<div style="width:800px; margin-right:auto">
    <div class="menuitem"><a href="/Default.aspx" class="headermenu">Home</a></div>
    <div class="menuitem"><a href="/Pages/Member/Questions.aspx" class="headermenu">Question</a></div>
    <div class="menuitem"><a href="/Pages/Member/ExamDashboard.aspx" class="headermenu">Exam</a></div>
    <div class="menuitem"><a href="/Pages/Member/UserProfile.aspx" class="headermenu">Profile</a></div>
    <div class="menuitem"><a href="/Pages/Public/ContactUs.aspx" class="headermenu">Contant Us</a></div>
    <div class="menuitem"><a href="/Pages/Member/Statistics.aspx" class="headermenu">Statistics</a></div>    
    <div class="menuitem"><asp:HyperLink ID="hplLogin" NavigateUrl="/Login.aspx?Logout=True" runat="server" CssClass="headermenu">Log Out</asp:HyperLink></div>
    <div class="clearfloating"></div>
</div>