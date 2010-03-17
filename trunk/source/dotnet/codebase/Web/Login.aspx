<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    
    <div class="contentheading">Member Login</div>
    <div class="floatleft" style="width:60%">
        This page allows registered users to log in to members only section of planningprep.com. 
        If you are already a member please sign in below. If you are interested in becoming a member, 
        please visit the <a href="/Pages/Public/Register.aspx">join now</a> page.  
        If you have forgotten your login information, <a href="/Pages/Public/ForgotPassword.aspx">click here</a>.

    </div>



    <%--<table border="0" cellpadding="1" cellspacing="0" style="border-collapse:collapse; width:100%;">
        <tr>
            <td style="padding-top:100px;">--%>
<div class="floatright">
                <div id="divMessage" class="ErrorMessageBox" runat="server" visible="false" enableviewstate="false" style="margin-top:15px;"></div>
                
                <div style="width:300px; margin:0 auto; border:#F7941D 1px solid; padding:0px 10px 10px 10px; background-color:#FFFFFF;">
                  <table align="center" border="0" cellpadding="2" cellspacing="0" style="width:300px;">
                    <tr>
                        <td align="center" colspan="2" style="height:15px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName">Username</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="256" style="width:200px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                ControlToValidate="txtUserName"
                                ErrorMessage="Please enter a User Name." 
                                ToolTip="User Name is required." ValidationGroup="Login1">*
                            </asp:RequiredFieldValidator>                                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Password</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="256" style="width:200px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                ControlToValidate="txtPassword" ErrorMessage="Password is required." 
                                ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me next time." />
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="center" colspan="2" style="color:Red;">
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>                                        
                        </td>
                    </tr>--%>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left" style="padding-top:10px;">
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" CssClass="ButtonCommon" 
                                ValidationGroup="Login1" onclick="LoginButton_Click" />
                        </td>
                    </tr>
                </table>
                </div>
                </div>
 <div class="clearboth"></div>
            <%--</td>
        </tr>
    </table>--%>
                                                
</asp:Content>

