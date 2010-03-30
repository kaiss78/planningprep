<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Public_Login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContents" Runat="Server">
    <div>
        <h1>Login</h1>
        <div style="margin-top:10px;">
            Medstudy is providing this video lab to showcase what is available now and future products.
            We welcome your feedback.
        </div>
       
       <div id="divMessageBox" runat="server" visible="false"></div>
        
        <div style="margin-top:10px;">
            <div class="fl">Enter Email Id</div>
            <div class="fl" style="margin-left:10px;">
                <asp:TextBox ID="txtEmailId" CssClass="TextBoxCommon" MaxLength="150" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" 
                    ControlToValidate="txtEmailId" Display="Dynamic"
                    ErrorMessage="<br/>Please enter an Email." SetFocusOnError="true"
                    ValidationGroup="Login">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator id="revEmail" runat="server"
                    ControlToValidate="txtEmailId" Display="Dynamic"
                    ValidationExpression=".*@.*\..*"
                    ErrorMessage="<br/>Please provide a valid<br/>Email Id to Login." SetFocusOnError="true"
                    ValidationGroup="Login">
                </asp:RegularExpressionValidator>
            </div>
            <div class="fl" style="margin-left:10px;"><asp:Button ID="btnLogin" ValidationGroup="Login" CssClass="ButtonCommon" runat="server" Text="Login" OnClick="btnLogin_Click" /></div>
            <div class="clearBoth"></div>
        </div>
    </div>

</asp:Content>

