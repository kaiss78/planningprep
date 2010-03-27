<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateProfile.aspx.cs" Inherits="Pages_Public_CreateProfile" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        table td{
            vertical-align:top;
            padding-left:0px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContents" Runat="Server">
    <h1>Create New Profile</h1>
    
    <asp:Panel ID="pnlDetails" runat="server">    
        <div>
            Enter the following details and click Submit to create your New Profile.<br />
            Fields marked with an asterisk(<span class="requiredfiled">*</span>) are mandatory.
        </div>
        
        <div>
            <div id="divMessageBox" runat="server" visible="false"></div>
            <table cellpadding="3" cellspacing="0" style="width:100%;">
                <colgroup>
                    <col style="width:35%;" />
                    <col style="width:65%;" />
                </colgroup>
                <tr>
                    <td>Serial Key<span class="requiredfiled"><sup>*</sup></span></td>
                    <td>
                        <asp:TextBox ID="txtSerialKey" runat="server" CssClass="TextBoxCommon" MaxLength="255"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtSerialKey" Display="Dynamic"
                            ErrorMessage="<br/>Please enter a Serial Key." SetFocusOnError="true"
                            ValidationGroup="Register">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>First Name<span class="requiredfiled"><sup>*</sup></span></td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                            ControlToValidate="txtFirstName" Display="Dynamic"
                            ErrorMessage="<br/>Please enter a First Name." SetFocusOnError="true"
                            ValidationGroup="Register">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Middle Name<%--<span class="requiredfiled"><sup>*</sup></span>--%></td>
                    <td>
                        <asp:TextBox ID="txtMiddleName" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtMiddleName" Display="Dynamic"
                            ErrorMessage="<br/>Please enter a Middle Name."
                            ValidationGroup="Register">
                        </asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>Last Name<%--<span class="requiredfiled"><sup>*</sup></span>--%></td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtLastName" Display="Dynamic"
                            ErrorMessage="<br/>Please enter a Last Name."
                            ValidationGroup="Register">
                        </asp:RequiredFieldValidator>    --%>
                    </td>
                </tr>            
                <tr>
                    <td>Email<span class="requiredfiled"><sup>*</sup></span></td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic"
                            ErrorMessage="<br/>Please enter an Email." SetFocusOnError="true"
                            ValidationGroup="Register">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator id="revEmail" runat="server"
                            ControlToValidate="txtEmail" Display="Dynamic"
                            ValidationExpression=".*@.*\..*"
                            ErrorMessage="<br/>Please provide a valid Email Id to activate your account." SetFocusOnError="true"
                            ValidationGroup="Register">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Are you a Resident?</td>
                    <td>
                        <asp:DropDownList ID="ddlIsResident" CssClass="DropDownListCommon" runat="server">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Which year of Residency?</td>
                    <td>
                        <asp:DropDownList ID="ddlResidency" CssClass="DropDownListCommon" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <%--
                <tr>
                    <td>Username<span class="requiredfiled"><sup>*</sup></span></td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="TextBoxCommon" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                            ControlToValidate="txtUserName" Display="Dynamic"
                            ErrorMessage="<br/>Please enter a Username."
                            ValidationGroup="Register">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password<span class="requiredfiled"><sup>*</sup></span></td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBoxCommon" TextMode="Password" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                            ControlToValidate="txtPassword" Display="Dynamic"
                            ErrorMessage="<br/>Please enter a Password."
                            ValidationGroup="Register">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Re-Type Password<span class="requiredfiled"><sup>*</sup></span></td>
                    <td>
                        <asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="TextBoxCommon" TextMode="Password" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPasswordConfirm" runat="server" 
                            ControlToValidate="txtPasswordConfirm" Display="Dynamic"
                            ErrorMessage="<br/>Please Re-Type your Password."
                            ValidationGroup="Register">
                        </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvPasswordConfirm" runat="server" 
                            ControlToCompare="txtPassword" ControlToValidate="txtPasswordConfirm" Display="Dynamic"
                            ErrorMessage="<br/>Two Passwords are not same."
                            ValidationGroup="Register">
                        </asp:CompareValidator>
                    </td>
                </tr>--%>
              <%--  <tr>
                    <td>How Did You Hear About Us?<span class="requiredfiled"><sup>*</sup></span></td>
                    <td>
                        <asp:DropDownList ID="ddlHowHear" runat="server" CssClass="DropDownListCommon">
                            <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                            <asp:ListItem Value="A friend" Text="A friend"></asp:ListItem>
                            <asp:ListItem Value="A colleague" Text="A colleague"></asp:ListItem>
                            <asp:ListItem Value="Professional Development Officer" Text="Professional Development Officer"></asp:ListItem>
                            <asp:ListItem Value="Website" Text="Website"></asp:ListItem>
                            <asp:ListItem Value="Search Engine" Text="Search Engine"></asp:ListItem>
                            <asp:ListItem Value="Mailing" Text="Mailing"></asp:ListItem>
                            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="ddlHowHear" Display="Dynamic"
                            ErrorMessage="<br/>Please select that How Did You Hear About Us?"
                            ValidationGroup="Register">
                        </asp:RequiredFieldValidator>                                
                    </td>
                </tr>--%>        
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Text="Register" 
                            CssClass="ButtonCommon" ValidationGroup="Register" 
                            onclick="btnRegister_Click" />
                    </td>
               </tr>     
            </table>    
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlConfirmation" runat="server" Visible="false">
        <div>
            <asp:Label ID="lblSuccessMessage" runat="server" Text="A confirmation email has been sent to your email id {0}."></asp:Label>
            <div>
                Please click on the link provided in the email id for confirmation.
            </div>
        </div>
    </asp:Panel>        
</asp:Content>

