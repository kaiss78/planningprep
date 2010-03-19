<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Commenting.ascx.cs" Inherits="UserControls_Commenting" %>
      
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">        
        <Services>
            <asp:ServiceReference Path="~/Services/AjaxService.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    
    <script language="javascript" type="text/javascript">
        var _QuestionID = <%= _QuestionID.ToString()%>;
        var _UserID = <%= _UserID.ToString()%>;
        var _UserName = "<%= SessionCache.CurrentUser.Username %>";
        var _TotalCount = <%= _TotalCount.ToString()%>;
        var _Comment = new App.Models.Comments.Comment();
        
        function SaveCommentData()
        {   
            _Comment.CommentText = $('#<%=txtComment.ClientID%>').val();
            _Comment.UserID = _UserID;
            _Comment.QuestionID = _QuestionID;
            AjaxService.SaveComment(_Comment, SaveComment_Success, SaveComment_Failiure);
        }        
        function SaveComment_Success(result)
        {
            var commentId = result;
            var className = (_TotalCount % 2) == 0 ? 'OddRowListing' : 'EvenRowListing';
            var domElement = '<div class="' + className + '">';
            domElement += String.format('<div class="commentuserbox">{0}<br /><span class="minutesago">0 Minutes ago</span></div>', _UserName);
            domElement += '<div class="commentbox">"' + FormatText(_Comment.CommentText) + '"</div>';            
            domElement += GetThumbsHtml(0, true);            
            if(_TotalCount == 0)               
                $('#divCommentListHeading').show();
                
            $('#divCommentingList').append(domElement);            
            $('#<%=txtComment.ClientID%>').val('');
            _TotalCount++;
            ToggleCommentingBox();
            ///Change Scroll Position to the new comment                    
            $(window).scrollTop($('#divCommentingList div:last-child').position().top);
                               
        }
        function GetThumbsHtml(count, isSameUser)
        {
            var domElement = '<div class="commentboxforthumbs">';
            if(isSameUser)
                domElement += String.format('<div class="thumbText">{0}&nbsp;</div><div class="thumbImage"><img src="/Images/ThumbsDown_Disabled.png" alt="Thumbs Down Disabled" title="Thumbs Down Disabled"/> <img src="/Images/ThumbsUp_Disabled.png" alt="Thumbs Up Disabled" title="Thumbs Up Disabled"/></div><div class="clearfloating"></div>', GetLogicalText(count, 'Thumb'));
            else
                domElement += String.format('<div class="thumbText">{0}&nbsp;</div><div class="thumbImage"><img src="/Images/ThumbsDown.png" onclick="ThumbsDown({1}, this);" alt="Thumbs Down" title="Thumbs Down this Comment" class="clickableimage"/> <img src="/Images/ThumbsUp.png" onclick="ThumbsUp({1}, this);" alt="Thumbs Up this Comment" title="Thumbs Up" class="clickableimage"/></div><div class="clearfloating"></div>', GetLogicalText(count, 'Thumb'));
            domElement += '</div>';
            domElement += '<div class="clearboth"></div>';
            domElement += '</div>';
            return domElement;
        }
        function SaveComment_Failiure(error)
        {
            CreateConfirmationPopup('confirm', 'Error', '<%=AppConstants.ERROR_MESSAGE %>');
            //alert(error.get_message());
        }
        
        ///Thumbs Up and Down 
        var _ImgElement = null;
        function ThumbsUp(commentID, imgElement)
        {
            _ImgElement = imgElement;
            AjaxService.CommentThumbsUp(commentID, CommentThumbsUp_Success, CommentThumbsUp_Failiure);
        }
        function CommentThumbsUp_Success(result)
        {
            var thumbsCount = result;
            $(_ImgElement).parent().parent().find('.thumbText').html(GetLogicalText(thumbsCount, 'Thumb') + '&nbsp;');
            CreateConfirmationPopup('confirm', 'Thumbs Up', 'Thank you!<br/>Thumbs Up information for this comment has been saved successfully.');
            //alert('Your preference saved successfully.');
        }
        function CommentThumbsUp_Failiure(error)
        {
            CreateConfirmationPopup('confirm', 'Error', '<%=AppConstants.ERROR_MESSAGE %>');
            //alert(error.get_message());
        }   
        function ThumbsDown(commentID, imgElement)
        {
             _ImgElement = imgElement;
            AjaxService.CommentThumbsDown(commentID, CommentThumbsDown_Success, CommentThumbsDown_Failiure);
        }        
        function CommentThumbsDown_Success(result)
        {
            var thumbsCount = result;
            $(_ImgElement).parent().parent().find('.thumbText').html(GetLogicalText(thumbsCount, 'Thumb') + '&nbsp;');    
            CreateConfirmationPopup('confirm', 'Thumbs Down', 'Thank you!<br/>Your Thumbs Down information for this comment has been saved successfully.');
            //alert('Your preference saved successfully.');   
        }
        function CommentThumbsDown_Failiure(error)
        {
            CreateConfirmationPopup('confirm', 'Error', '<%=AppConstants.ERROR_MESSAGE %>');
            //alert(error.get_message());
        }   
        
        function ToggleCommentingBox() 
        {
            if($('#divCommentingTextBox').is(':visible'))            
                $('#divCommentingTextBox').fadeOut();            
            else
            {
                $('#divCommentingTextBox').fadeIn();
                $('#<%=txtComment.ClientID%>').val('')
            }               
        }      
        
    </script>

<div id="divCommentingList">
    <div class="contentheading"><asp:Literal ID="ltrCommentHeading" runat="server"></asp:Literal></div>
    <div id="divCommentingTextBox" style="display:none;">    
        <asp:TextBox ID="txtComment" TextMode="MultiLine" MaxLength="2000" runat="server" style="width:350px; height:75px;"></asp:TextBox>
        <div style="margin-top:5px; margin-bottom:10px;"><input type="button" value="Save Comment" class="ButtonCommon" onclick="SaveCommentData();" /></div>    
    </div>
    <%--<div class="contentheading" id="divCommentListHeading" style="display:<%=_CommentListDisplayStyle %>;">Comments</div>--%>
    <asp:Repeater ID="rptCommentList" runat="server" onitemdatabound="rptCommentList_ItemDataBound">
        <ItemTemplate>
            <div class="OddRowListing">
                <div class="commentuserbox"><asp:Literal ID="ltrUserInfo" runat="server"></asp:Literal></div>
                <div class="commentbox"><asp:Literal ID="ltrComment" runat="server"></asp:Literal></div>
                <div class="commentboxforthumbs"><asp:Literal ID="ltrThumbs" runat="server"></asp:Literal></div>                
                <div class="clearboth"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="EvenRowListing">
                <div class="commentuserbox"><asp:Literal ID="ltrUserInfo" runat="server"></asp:Literal></div>
                <div class="commentbox"><asp:Literal ID="ltrComment" runat="server"></asp:Literal></div>
                <div class="commentboxforthumbs"><asp:Literal ID="ltrThumbs" runat="server"></asp:Literal></div>
                <div class="clearboth"></div>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>    
</div>