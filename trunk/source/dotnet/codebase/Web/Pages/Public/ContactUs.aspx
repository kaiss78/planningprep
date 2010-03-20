<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Pages_Public_ContactUs" 
    Title="Untitled Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        table td
        {
        	padding-left:0px;
        	vertical-align:top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="homepagecontentbox">
        <div class="contentheading">Contact Us</div>
        
        <div id="divPrivateMessage" style="margin-bottom:15px;" runat="server" visible="false">
            Please use the form below to send a message to Planning 
	        Prep.  We are always looking for ways to make the site more useful to our 
	        members. Feel free to let us know if there are areas or topics that you 
	        would like to see expanded. Also contact us for any general questions about 
	        our site or services. Simply use the form below to send us a message. We 
	        value all input as we continually strive to make the site better for 
	        everyone.	
	        <br /><br />
	        Please note that the email and name fields are populated from your 
	        account information.        
        </div>
        
        <div id="divPublicMessage" runat="server" style="margin-bottom:15px;">
            <%--Please use the form below to send planningprep.com a message. Please note that the email and name fields are mandatory.--%>
            Please use the form below to send planningprep.com a message. Please note that fields marked with an asterisk (<span class="requiredfiled">*</span>) are mandatory.     
	    </div>    
        
        
        <table cellpadding="3" cellspacing="0" style="width:100%;">
            <colgroup>
                <col style="width:20%;" />
                <col style="width:80%;" />
            </colgroup>
            <tr>
                <td>Name<span id="spnName" runat="server" class="requiredfiled"><sup>*</sup></span></td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="TextBoxCommon" MaxLength="110"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                        ControlToValidate="txtName" Display="Dynamic"
                        ErrorMessage="<br/>Please enter an Email."
                        ValidationGroup="ContactUs">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Email<span id="spnEmail" runat="server" class="requiredfiled"><sup>*</sup></span></td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBoxCommon" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                        ControlToValidate="txtEmail" Display="Dynamic"
                        ErrorMessage="<br/>Please enter an Email."
                        ValidationGroup="ContactUs">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator id="revEmail" runat="server"
                        ControlToValidate="txtEmail" Display="Dynamic"
                        ValidationExpression=".*@.*\..*"
                        ErrorMessage="<br/>Please enter a valid Email address."
                        ValidationGroup="ContactUs">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Subject<span class="requiredfiled"><sup>*</sup></span></td>
                <td>
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="TextBoxCommon" MaxLength="300" style="width:98%;"></asp:TextBox>   
                    <asp:RequiredFieldValidator ID="rfvSubject" runat="server" 
                        ControlToValidate="txtSubject" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Subject."
                        ValidationGroup="ContactUs">
                    </asp:RequiredFieldValidator>           
                </td>
            </tr>
            <tr>
                <td>Comments<span class="requiredfiled"><sup>*</sup></span></td>
                <td>
                    <asp:TextBox ID="txtComment" TextMode="MultiLine" runat="server" MaxLength="2000" style="width:98%; height:100px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvComment" runat="server" 
                        ControlToValidate="txtComment" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Comment."
                        ValidationGroup="ContactUs">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>   
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" ValidationGroup="ContactUs" OnClick="btnSendMessage_Click" />                    
                </td>
            </tr>     
        </table>
    </div>          
    
    <div class="homepagecontentbox">
        <div class="contentheading">Address</div>
        <div id="divPrivateAddress" runat="server" visible="false">
            <b>Planning Prep</b><br />
            <a href="<%=AppUtil.GetDomainAddress()%>"><%=AppUtil.GetDomainAddress().Replace("http://", String.Empty).Replace("/", String.Empty) %></a><br />
            1235 North Webster Street<br />
            Naperville, IL  60563
            <br /><br />
            Support: <a href="mailto:<%=ConfigReader.SupportEmail %>"><%=ConfigReader.SupportEmail %></a><br />
            Billing: <a href="mailto:<%=ConfigReader.SupportEmail %>"><%=ConfigReader.SupportEmail %></a><br />
        </div>
        
        <div id="divPublicAddress" runat="server">
            <b>Planning Prep</b><br />
            <a href="<%=AppUtil.GetDomainAddress()%>"><%=AppUtil.GetDomainAddress().Replace("http://", String.Empty).Replace("/", String.Empty)%></a><br/>
            C/O HLA<br/>
            114 E Van Buren #2C<br/>
            Naperville, IL 60540
            <br /><br />
            Support &amp; Billing <a href="mailto:<%=ConfigReader.SupportEmail %>"><%=ConfigReader.SupportEmail %></a><br />            
        </div>
    </div>
    <div class="clearfloating"></div>   
    
</asp:Content>

