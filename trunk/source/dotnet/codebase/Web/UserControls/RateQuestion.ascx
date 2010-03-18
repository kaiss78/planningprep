<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RateQuestion.ascx.cs"
    Inherits="UserControls_RateQuestion" %>   
    
    
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">        
        <Services>
            <asp:ServiceReference Path="~/Services/AjaxService.asmx" />
        </Services>
    </asp:ScriptManagerProxy>    
    
    <script language="javascript" type="text/javascript">
        var _QuestionID = <%= _QuestionID %>;
        var _SelectedRating = 0;
        
        function SaveRating()
        {
            _SelectedRating = $('#<%= rdoRating.ClientID%> input[type=radio]:checked').val();     
            if(_SelectedRating == undefined)            
                CreateConfirmationPopup('confirm', 'Error', 'Please select a rating.');                            
            else            
                AjaxService.SaveQuestionRating(_QuestionID, _SelectedRating, SaveRating_Success, SaveRating_Failure);            
        }
        function SaveRating_Success(result)
        {
            CreateConfirmationPopup('confirm', 'Question Rating', 'Thank you!<br/>Your rating for this question has been saved successfully.');
            $('#<%=divRate.ClientID %>').fadeOut();
        }
        function SaveRating_Failure(error)
        {
            CreateConfirmationPopup('confirm', 'Error', '<%=AppConstants.ERROR_MESSAGE %>');
            //alert(error.get_message());
        }
    </script>    
    
<div runat="server" id="divRate" class="divRate">
    <b>Rate This Question</b>
    <asp:RadioButtonList ID="rdoRating" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Text="1" Value="1"></asp:ListItem>
        <asp:ListItem Text="2" Value="2"></asp:ListItem>
        <asp:ListItem Text="3" Value="3"></asp:ListItem>
        <asp:ListItem Text="4" Value="4"></asp:ListItem>
        <asp:ListItem Text="5" Value="5"></asp:ListItem>
    </asp:RadioButtonList> 
    <%--<asp:Button ID="btnSubmitRate" runat="server" Text="Rate" CssClass="ButtonCommon" style="width:auto;" onclick="btnSubmitRate_Click" />--%> 
    <input type="button" value="Rate" class="ButtonCommon" style="width:auto;" onclick="SaveRating();" />
<p>
    Why Rate? Questions with lower ratings are improved or removed, and questions with
    higher ratings receive a higher priority within the pool of questions."
</p>
</div>
<div runat="server" id="divRated">
    <b>Thanks for Rating This Question</b>
</div>
