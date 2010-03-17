<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserProfile.ascx.cs" Inherits="UserControls_UserProfile" %>

<div>
<div class="ErrorMessageBox" id="divErrorMessage" visible="false" runat="server" style="margin-top:15px;"></div>
    <div class="contentheading"><asp:Literal ID="ltrProfileHeading" runat="server"></asp:Literal></div>    
    
    <div id="divInfoText" runat="server" style="margin-bottom:15px;" visible="false">
        This page lets you view your data in our membership database. If you would like to change any of this information 
        <asp:HyperLink ID="hplProfileEdit" runat="server">click here</asp:HyperLink>.
    </div>
    
    <%if (IsEditMode){ %>
    <asp:Panel ID="pnlEditProfile" runat="server" DefaultButton="btnSave">    
        <table cellpadding="3" cellspacing="0" style="width:100%;">    
            <colgroup>
                <col style="width:16%;" />
                <col style="width:84%;" />
            </colgroup>
            <tr>
                <td>Username<sup>+</sup></td>
                <td><asp:Label ID="lblUserNameEdit" runat="server"></asp:Label><asp:TextBox ID="txtUserName" Visible="false" runat="server" CssClass="TextBoxCommon" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" Visible="false" runat="server" 
                        ControlToValidate="txtUserName" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Username."
                        ValidationGroup="SaveProfile">
                    </asp:RequiredFieldValidator></td>            
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password" CssClass="TextBoxCommon" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="refPassword" runat="server" 
                        ControlToValidate="txtUserPassword" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Password."
                        ValidationGroup="SaveProfile">
                    </asp:RequiredFieldValidator> 
                </td>            
            </tr>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                        ControlToValidate="txtFirstName" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a First Name."
                        ValidationGroup="SaveProfile">
                    </asp:RequiredFieldValidator>
                </td>            
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="refLastName" runat="server" 
                        ControlToValidate="txtLastName" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Last Name."
                        ValidationGroup="SaveProfile">
                    </asp:RequiredFieldValidator>   
                </td>            
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                        ControlToValidate="txtEmail" Display="Dynamic"
                        ErrorMessage="<br/>Please enter an Email."
                        ValidationGroup="SaveProfile">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator id="revEmail" runat="server"
                        ControlToValidate="txtEmail" Display="Dynamic"
                        ValidationExpression=".*@.*\..*"                    
                        ErrorMessage="<br/>Please enter a valid Email address."
                        ValidationGroup="SaveProfile">
                    </asp:RegularExpressionValidator>
                </td>            
            </tr>
            <tr>
                <td>Home Page</td>
                <td><asp:TextBox ID="txtHomePage" runat="server" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox></td>            
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="refAddress" runat="server" 
                        ControlToValidate="txtAddress" Display="Dynamic"
                        ErrorMessage="<br/>Please enter an Address."
                        ValidationGroup="SaveProfile">
                    </asp:RequiredFieldValidator>
                </td>            
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" 
                        ControlToValidate="txtCity" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a City."
                        ValidationGroup="SaveProfile">
                    </asp:RequiredFieldValidator>
                </td>            
            </tr>
            <tr>
                <td>State</td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" 
                        ControlToValidate="txtState" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a State."
                        ValidationGroup="SaveProfile">
                    </asp:RequiredFieldValidator>
                </td>            
            </tr>
            <tr>
                <td>Zip</td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" 
                        ControlToValidate="txtZip" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Zip."
                        ValidationGroup="SaveProfile">
                    </asp:RequiredFieldValidator>    
                </td>            
            </tr>
            <tr>
                <td>Phone Number</td>
                <td>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>                
                </td>            
            </tr>
            <tr>
                <td><asp:Label Text="Date Joined" ID="lblDateJoinedLabel" runat="server" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblDateJoinedEdit" runat="server" runat="server"></asp:Label></td>            
            </tr>
            <tr>
                <td>Question Mode</td>
                <td>
                    <asp:DropDownList ID="ddlQuestionMode" runat="server" CssClass="DropDownListCommon">
                        <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                        <asp:ListItem Text="Filtered" Value="Filtered"></asp:ListItem>
                        <asp:ListItem Text="See All Questions" Value="See All Questions"></asp:ListItem>
                    </asp:DropDownList>                
                </td>            
            </tr>        
            <tr>
                <td colspan="2"><sup>+</sup> Indicates items that cannot be changed.</td>
            </tr>  
            <tr>
                <td colspan="2"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ButtonCommon" ValidationGroup="SaveProfile" onclick="btnSave_Click"/></td>
            </tr>      
        </table>    
    </asp:Panel>
    
    <%}else{ %>
    
    <asp:Panel ID="pnlUserProfile" runat="server">
        <table cellpadding="3" cellspacing="0" style="width:100%;">    
            <colgroup>
                <col style="width:16%;" />
                <col style="width:84%;" />
            </colgroup>
            <tr>
                <td>Username</td>
                <td><asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>Password</td>
                <td><asp:Label ID="lblPassword" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>First Name</td>
                <td><asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>Last Name</td>
                <td><asp:Label ID="lblLastName" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>Email</td>
                <td><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>Home Page</td>
                <td><asp:Literal ID="ltrHomePage" runat="server" Text=""></asp:Literal></td>            
            </tr>
            <tr>
                <td>Address</td>
                <td><asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>City</td>
                <td><asp:Label ID="lblCity" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>State</td>
                <td><asp:Label ID="lblState" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>Zip</td>
                <td><asp:Label ID="lblZip" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>Phone Number</td>
                <td><asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>Date Joined</td>
                <td><asp:Label ID="lblDateJoined" runat="server" Text=""></asp:Label></td>            
            </tr>
            <tr>
                <td>Question Mode</td>
                <td><asp:Label ID="lblQuestionMode" runat="server" Text=""></asp:Label></td>            
            </tr>                
        </table>    
    </asp:Panel>
    <%} %>    
</div>