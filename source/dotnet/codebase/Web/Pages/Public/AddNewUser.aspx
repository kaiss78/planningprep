<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewUser.aspx.cs" Inherits="AddNewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div class="PageHeader" style="margin-bottom:10px;">Create New User</div>
            
            <div id="divMessage" class="MessageBox" runat="server" visible="false" enableviewstate="false"></div>
            
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" oncreateduser="CreateUserWizard1_CreatedUser" 
                oncreatinguser="CreateUserWizard1_CreatingUser" Width="100%" 
                oncreateusererror="CreateUserWizard1_CreateUserError">
            
                <CreateUserButtonStyle CssClass="ButtonCommon" />
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    <ContentTemplate>
                        <table class="tblDataEntryForm" border="0" cellpadding="0" cellspacing="0" style="width:100%;">
                            <colgroup>
                                <col style="width:15%;" />
                                <col style="width:85%;" />
                            </colgroup>
                            <tr>
                                <td colspan="2" style="line-height:10px; height:10px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>                                    
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="Please enter an <b>User Name</b." 
                                        ToolTip="User Name is required." SetFocusOnError="true" Display="None" 
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" Display="None" SetFocusOnError="true" 
                                        ErrorMessage="Please enter a <b>Password</b>." 
                                        ToolTip="Password is required." ValidationGroup="CreateUserWizard1">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                        AssociatedControlID="ConfirmPassword">Confirm Password</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                        ControlToValidate="ConfirmPassword" Display="None" SetFocusOnError="true" 
                                        ErrorMessage="Please enter <b>Confirmation Password</b>." 
                                        ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">
                                        
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                        ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                        ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="vertical-align: top; padding-top: 3px">
                                    User Role
                                </td>
                                <td>
                                    <asp:ListBox ID="AvailableRoles"  runat="server" SelectionMode="Multiple" Height="104px"
                                        Width="264px"></asp:ListBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="[Select Role]"
                                        ControlToValidate="AvailableRoles" ErrorMessage="Select at least one Role" ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                        ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                        Display="None" 
                                        ErrorMessage="The Password and Confirmation Password must match." 
                                        ValidationGroup="CreateUserWizard1">
                                    </asp:CompareValidator>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>                   
    </div>
    </form>
</body>
</html>
