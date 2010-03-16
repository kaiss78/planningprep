<%@ Page Language="C#" MasterPageFile="~/Pages/Public/MasterPagePublic.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" 
    Inherits="Pages_Public_Register" Title="Untitled Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        table td{
            vertical-align:top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    
    <div class="contentheading">Register Now</div>
    <div id="divPromo" runat="server" visible="false" style="font-weight:bold; margin-bottom:15px;">
        Sorry, your free trial has ended. Unfortunately we cannot give our site away for free. As you have seen in your visit, 
        our staff and Board has worked extremely hard in preparing content for the site. Each day we continue to add additional 
        questions and content to help our members prepare for the AICP exam. If you are interested in becoming a member, 
        please use the form below to join. Once again, thank you, and good luck.
        <br /><br />
        If you believe you have been redirected here in error, please <a href= "/Pages/Public/ContactUs.aspx">contact us</a>. 
    </div>
    
    <div>
        Please complete the form below to register to 
        Planning Prep. Registration to the site costs $120. <b>Memberships 
        are valid for 1 year.</b>
        Complete the form below and click Register and you will be taken to details on 
        payment. Remember, all of the fields below are mandatory.
    </div>
    
    <div class="ErrorMessageBox" id="divErrorMessage" visible="false" runat="server" style="margin-top:15px;"></div>
    <div style="float:left; width:550px; margin-top:20px; border-right:#C0C0C0 1px solid;">
        <table cellpadding="3" cellspacing="0" style="width:100%;">
            <colgroup>
                <col style="width:35%;" />
                <col style="width:65%;" />
            </colgroup>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                        ControlToValidate="txtFirstName" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a First Name."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtLastName" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Last Name."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>    
                </td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtAddress" Display="Dynamic"
                        ErrorMessage="<br/>Please enter an Address."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" 
                        ControlToValidate="txtCity" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a City."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>State</td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" 
                        ControlToValidate="txtState" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a State."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>ZIP</td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" 
                        ControlToValidate="txtZip" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Zip."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Employer</td>
                <td>
                    <asp:TextBox ID="txtEmployer" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmployer" runat="server" 
                        ControlToValidate="txtEmployer" Display="Dynamic"
                        ErrorMessage="<br/>Please enter an Employer."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Title/Position</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" 
                        ControlToValidate="txtTitle" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Title/Position."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="txtEmail" Display="Dynamic"
                        ErrorMessage="<br/>Please enter an Email."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator id="revEmail" runat="server"
                        ControlToValidate="txtEmail"
                        ValidationExpression=".*@.*\..*"
                        ErrorMessage="<br/>Please enter a valid Email address."
                        display="Dynamic">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Re-Type Email</td>
                <td>
                    <asp:TextBox ID="txtEmailConfirm" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmailConfirm" runat="server" 
                        ControlToValidate="txtEmailConfirm" Display="Dynamic"
                        ErrorMessage="<br/>Please Re-Type your Email."
                        ValidationGroup="Register">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvEmailConfirm" runat="server" 
                        ControlToCompare="txtEmail" ControlToValidate="txtEmailConfirm" Display="Dynamic"
                        ErrorMessage="<br/>Two Emails are not same."
                        ValidationGroup="Register">
                    </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>Username</td>
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
                <td>Password</td>
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
                <td>Re-Type Password</td>
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
            </tr>
            <tr>
                <td>How Did You Hear About Us</td>
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
                    <%--Dropdown List Values are Taken from old Join.asp Code--%>                
                </td>
            </tr>        
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" 
                        CssClass="ButtonCommon" ValidationGroup="Register" 
                        onclick="btnRegister_Click" />
                </td>
           </tr>     
        </table>
    </div>
    <div style="float:left; width: 210px; padding-left:20px; margin-top:20px;">
        Planning Prep takes memberships and the terms of use 
        policy very seriously. Users are not permitted to share accounts and 
        passwords. Our site logs all network and account activity to monitor and 
        secure the site. To report a violation of our terms of service, click 
        here. <br /><br />
        We thank you for your cooperation. &nbsp;    
    </div>
    <div class="clearboth"></div>

</asp:Content>

