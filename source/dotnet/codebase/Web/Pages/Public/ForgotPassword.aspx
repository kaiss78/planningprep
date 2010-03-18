<%@ Page Language="C#" MasterPageFile="~/Pages/Public/MasterPagePublic.master" AutoEventWireup="true" 
    CodeFile="ForgotPassword.aspx.cs" Inherits="Pages_Public_ForgotPassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">    
    <div class="contentheading">Lost Login Information</div>    
    
    <asp:Panel ID="pnlMessage" runat="server">    
        If you have lost or forgotten your username or password, simply type your email address in the form below and press Send.        
    </asp:Panel>
    
    <div id="divMessageBox" runat="server" visible="false" style="margin-top:15px;"></div>
    
    <asp:Panel ID="pnlDetails" runat="server" DefaultButton="btnSend">    
        <div style="margin-top:15px; margin-bottom:15px;">
            Email Address <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="txtEmail" Display="Dynamic"
                ErrorMessage="<br/>Please enter an Email Address."
                ValidationGroup="Send">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="revEmail" runat="server"
                ControlToValidate="txtEmail" Display="Dynamic"
                ValidationExpression=".*@.*\..*"
                ErrorMessage="<br/>Please enter a valid Email address."
                ValidationGroup="Send">
            </asp:RegularExpressionValidator>      
        </div>
        <div>
            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="ButtonCommon" onclick="btnSend_Click" ValidationGroup="Send" />
        </div>
    </asp:Panel>
</asp:Content>

