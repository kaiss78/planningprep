<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="SendEmail.aspx.cs" Inherits="Pages_Admin_SendEmail" Title="Untitled Page" %>

<%@ Register Src="/UserControls/ModalMessage.ascx" TagName="ModalMessage" TagPrefix="UC" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">   
    <link href="/CSS/ModalPopup.css" rel="Stylesheet" type="text/css" />
     <style type="text/css">
        table td
        {
        	padding-left:0px;
        	vertical-align:top;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>

    <div class="contentheading">Send Message to Members</div>
    <div id="divUserInfo" runat="server">
        This page will send a message to all Planning Prep members. It is for notifying them of promotions, 
        scheduled maintenance, and any other detail you would like the members to know about. 
    </div>
    
    <div id="divProcessingAnimation" style="display:none; margin-top:15px;">
        <b>Sending emails. Please wait...</b><br />
        <img src="/Images/processing.gif" alt="Processing" title="Processing" />
    </div>
    
    <%--Left Box--%>
    <div id="divContainer" runat="server" class="homepagecontentbox" style="margin-top:15px;">
        <div style="margin-bottom:10px;">Please note that fields marked with an asterisk (<span class="requiredfiled">*</span>) are mandatory.</div>    
        <table cellpadding="3" cellspacing="0" style="width:100%;">
            <colgroup>
                <col style="width:20%;" />
                <col style="width:80%;" />
            </colgroup>
            <tr>
                <td>Name</td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td>Subject<span class="requiredfiled"><sup>*</sup></span></td>
                <td>
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="TextBoxCommon" MaxLength="300" style="width:98%;"></asp:TextBox>   
                    <asp:RequiredFieldValidator ID="rfvSubject" runat="server" 
                        ControlToValidate="txtSubject" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Subject."
                        ValidationGroup="SendMessage">
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
                        ValidationGroup="SendMessage">
                    </asp:RequiredFieldValidator>
                    
                    
                    <%--Dummy Validation Control to Stop Postback--%>
                    
                    
                </td>
            </tr>   
            <tr>
                <td>&nbsp;</td>
                <td>
                    <input type="button" value="Send Message" class="ButtonCommon" onclick="SendMessage();"/>
                    <%--<asp:Button ID="btnSendMessage" runat="server" Text="Send Message" ValidationGroup="SendMessage" OnClientClick="SendMessage(); return false;" />--%>
                </td>
            </tr>     
        </table>    
    </div>
    
    <%--Right Box--%>
    <div class="homepagecontentbox">
        &nbsp;
    </div>
    <div class="clearfloating"></div>
    
    <script language="javascript" type="text/javascript">
    
        var _AdminMessage = new AdminMessage();
        function SendMessage()
        {
            _AdminMessage.Subject = jQuery.trim($('#<%=txtSubject.ClientID %>').val());
            _AdminMessage.MessageBody = jQuery.trim($('#<%=txtComment.ClientID %>').val());    
            if(_AdminMessage.Subject.length > 0 && _AdminMessage.MessageBody.length > 0)
            {                    
                $('#<%=divContainer.ClientID %>').fadeOut(150, function(){                
                    $('#divProcessingAnimation').fadeIn(150, function(){
                        PageMethods.SendMessage(_AdminMessage, SendMessage_Success, SendMessage_Error);
                    });
                });
                $('#<%=txtSubject.ClientID %>').val('')
                $('#<%=txtComment.ClientID %>').val('')
            }
            ///Show Validation Messages
            else
            {
                if(_AdminMessage.Subject.length == 0)
                    $('#<%=rfvSubject.ClientID %>').show();
                if(_AdminMessage.MessageBody.length == 0)
                    $('#<%=rfvComment.ClientID %>').show();
            }
        }
        function SendMessage_Success(result)
        {
            if(result == -1)            
                ShowErroMessage('Critical Error', 'Please provide necessary information to send emails to the users.');
                //CreateConfirmationPopup('confirm', 'Critical Error', 'Please provide necessary information to send emails to the users.');                
            else
            {
                var emailCount = result == 1 ? '1 Email was' : result + ' Emails were'; 
                ///As jQuery Show Hide is Not working here
                document.getElementById('divProcessingAnimation').style.display = 'none';                
                CreateConfirmationPopup('confirm', 'Information', 'Congratulations!<br />Total ' + emailCount + ' successfully sent to the corresponding users. <a href="<%=AppConstants.Pages.MANAGE_USERS%>">Click Here</a> to Go Back to Manage Users Page');                
            }
        }
        function SendMessage_Error(Error)
        {
            ShowErroMessage('Error', '<%=AppConstants.ERROR_MESSAGE %>');            
        }           
        function ShowErroMessage(popupTitle, message)
        {
            document.getElementById('divProcessingAnimation').style.display = 'none';            
            CreateConfirmationPopup('confirm', popupTitle, message);            
            $('#<%=divContainer.ClientID %>').fadeIn('slow');
        }
    </script>
    
    <UC:ModalMessage ID="ucModalMessage" runat="server" />    
    
</asp:Content>

