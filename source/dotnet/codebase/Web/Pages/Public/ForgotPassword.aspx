<%@ Page Language="C#" MasterPageFile="~/Pages/Public/MasterPagePublic.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Pages_Public_ForgotPassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="contentheading">Lost Login Information</div>    
    If you have lost or forgotten your username or password, simply type your email address in the form below and press Send.
    <div id="divMessageBox" runat="server" visible="false" style="margin-top:15px;"></div>
    
    <div style="margin-top:15px; margin-bottom:15px;">
        Email Address <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBoxCommon"></asp:TextBox>        
    </div>
    <div>
        <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="ButtonCommon" onclick="btnSend_Click" />
    </div>
</asp:Content>

