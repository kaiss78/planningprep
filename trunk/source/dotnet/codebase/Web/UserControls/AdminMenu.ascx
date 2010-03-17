﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="UserControls_AdminMenu" %>

<div style="width:600px; margin-right:auto">
    <div class="menuitem"><a href="/Pages/Admin/Default.aspx" class="headermenu">My Dashboard</a></div>
    <div class="menuitem"><a href="/Pages/Admin/ManageQuestions.aspx" class="headermenu">Manage Questions</a></div>
    <div class="menuitem"><a href="/Pages/Admin/ManageUsers.aspx" class="headermenu">Manage Users</a></div>
    <%--<div class="menuitem">Contant Us</div>
    <div class="menuitem">FAQ</div>
    <div class="menuitem">Join</div>--%>
    <div class="menuitem"><a href="/Login.aspx?Logout=true" class="headermenu">Log Out</a></div>
    <div class="clearfloating"></div>
</div>