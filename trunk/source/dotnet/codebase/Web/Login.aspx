<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="CSS/Styles.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%--<asp:Login ID="Login1" runat="server" CreateUserUrl="~/AddNewUser.aspx" 
            Width="100%" onloginerror="Login1_LoginError">
            <LayoutTemplate>
    --%>            
                <table border="0" cellpadding="1" cellspacing="0" style="border-collapse:collapse; width:100%;">
                    <tr>
                        <td style="padding-top:100px;">
                            
                            <div id="divMessage" class="ErrorMessageBox" runat="server" visible="false" enableviewstate="false"></div>
                            
                            <div style="width:300px; margin:0 auto; margin-top:10px; border:#F7941D 1px solid; padding:0px 10px 10px 10px; background-color:#FFFFFF;">
                                <table align="center" border="0" cellpadding="2" cellspacing="0" style="width:300px;">
                                <tr>
                                    <td align="center" colspan="2" style="height:20px;"><b>User Log In</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUserName">User Name</asp:Label>
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
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                            ValidationGroup="Login1" onclick="LoginButton_Click" />
                                    </td>
                                </tr>
                            </table>
                            </div>
                        </td>
                    </tr>
                </table>
            <%--</LayoutTemplate>
        </asp:Login>--%>

    </div>
    </form>
</body>
</html>
