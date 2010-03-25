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
        var _UserFullName = "<%= string.Format("{0} {1}",SessionCache.CurrentUser.FirstName,SessionCache.CurrentUser.LastName) %>";
        var _TotalCount = <%= _TotalCount.ToString()%>;
        var _Comment = new App.Models.Comments.Comment();
        
        function SaveCommentData()
        {  
            _Comment.CommentText = jQuery.trim($('#<%=txtComment.ClientID%>').val());            
            if(_Comment.CommentText.length == 0)
            {
                $('#spnValidationMessage').fadeIn();
                $('#<%=txtComment.ClientID%>').focus();
                return;
            }
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
            $('#spnValidationMessage').fadeOut();                   
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
        }
        
        ///Thumbs Up and Down 
        var _ImgElement = null;
        function ThumbsUp(commentID, imgElement)
        {
            _ImgElement = imgElement;            
            AjaxService.CommentThumbsUp(commentID, _UserID, _QuestionID, CommentThumbsUp_Success, CommentThumbsUp_Failiure);
        }
        function CommentThumbsUp_Success(result)
        {
            var thumbsCount = result;
            $(_ImgElement).parent().parent().find('.thumbText').html(GetLogicalText(thumbsCount, 'Thumb') + '&nbsp;');
            DisableThumbImages();            
            CreateConfirmationPopup('confirm', 'Thumbs Up', 'Thanks. <br/>This comment has been Thumbed up!');            
        }
        function CommentThumbsUp_Failiure(error)
        {
            CreateConfirmationPopup('confirm', 'Error', '<%=AppConstants.ERROR_MESSAGE %>');            
        }   
        function ThumbsDown(commentID, imgElement)
        {
             _ImgElement = imgElement;
            AjaxService.CommentThumbsDown(commentID, _UserID, _QuestionID, CommentThumbsDown_Success, CommentThumbsDown_Failiure);
        }        
        function CommentThumbsDown_Success(result)
        {
            var thumbsCount = result;
            $(_ImgElement).parent().parent().find('.thumbText').html(GetLogicalText(thumbsCount, 'Thumb') + '&nbsp;');    
            DisableThumbImages();
            CreateConfirmationPopup('confirm', 'Thumbs Down', 'Thank you.<br/>This comment has been Thumbed down!');            
        }
        function CommentThumbsDown_Failiure(error)
        {
            CreateConfirmationPopup('confirm', 'Error', '<%=AppConstants.ERROR_MESSAGE %>');            
        }   
        function DisableThumbImages()
        {
            var imageHtml = '<img src="/Images/ThumbsDown_Disabled.png" alt="Thumbs Down Disabled" title="Thumbs Down Disabled"/> <img src="/Images/ThumbsUp_Disabled.png" alt="Thumbs Up Disabled" title="Thumbs Up Disabled"/>';
            $(_ImgElement).parent().parent().find('.thumbImage').fadeOut().html(imageHtml).fadeIn('slow');
        }
        function ToggleCommentingBox() 
        {
            if($('#divCommentingTextBox').is(':visible'))            
                $('#divCommentingTextBox').fadeOut();            
            else
            {
                $('#spnValidationMessage').hide();
                $('#divCommentingTextBox').fadeIn();
                $('#<%=txtComment.ClientID%>').val('').focus();
                
            }               
        }      
        /*$('body').click(function() {
            if($('#divCommentingTextBox').is(':visible'))            
                $('#divCommentingTextBox').fadeOut(); 
        });

        $('#divEventCatcher').click(function(event){
            event.stopPropagation();
        });*/
        
        ///Commenting Reply Section
        function ExpandCollapse(divElement)
        {
            alert(divElement.id);
        }
        var _ReplyHyperLink = null;
        function ShowPopupForCommentReply(commentID, hyperlinkElement)
        {
            _ReplyHyperLink = hyperlinkElement;
            //_ShowOKButton = false;            
            $('#divPopupButtonContainer').html(String.format('<input type="button" value="Reply to this Comment" class="ButtonCommon" onclick="SaveCommentReply({0}, this);"/>', commentID));                        
            CreateConfirmationPopup('confirm', 'Reply of Comment', '<textarea id="txtCommentReply" style="width:310px; height:100px;"/><span id="spnReplyValidationMessage" class="ErrorMessage">&nbsp;</span>');
            $('#txtCommentReply').focus();
        }
        
        var _CommentReply = new App.Models.Comments.CommentReply();
         
        function SaveCommentReply(commentID, btnElement)
        {            
            var reply = jQuery.trim($('#txtCommentReply').val());         
            if(reply.length == 0)                            
                document.getElementById('spnReplyValidationMessage').innerHTML = 'Please enter a <b>Reply</b> for this comment.';
                //$('#spnValidationMessage').html('Please enter a <b>Reply</b> for this comment.');            
            else
            {                
                _CommentReply.CommentID = commentID;
                _CommentReply.Message = reply;
                _CommentReply.UserID = _UserID;
                ///Hide Popup                
                HideConfirmationPopup('confirm');                
                
                ///Save Comment Reply
                AjaxService.SaveCommentReply(_CommentReply, SaveReply_Success, SaveReply_Failure);                  
            }            
        }
        function SaveReply_Success(result)
        {
            $('#divPopupButtonContainer').html('<input type="button" value="Ok" class="ButtonCommon" style="padding-right:0px; width:55px;" onclick="HideConfirmationPopup(\'confirm\');" />');
            if(result > 0)
            {                
                //CreateConfirmationPopup('confirm', 'Information', 'Thank You!<br/>Your reply has been saved successfully.');
                AddCommentToTheList(result);
            }
            else
                ShowErrorMessag();
        }
        function SaveReply_Failure(Error)
        {
            $('#divPopupButtonContainer').html('<input type="button" value="Ok" class="ButtonCommon" style="padding-right:0px; width:55px;" onclick="HideConfirmationPopup(\'confirm\');" />');
            ShowErrorMessag();    
        }
        function ShowErrorMessag()
        {
            //$('#divPopupButtonContainer').html('<input type="button" value="Ok" class="ButtonCommon" style="padding-right:0px; width:55px;" onclick="HideConfirmationPopup(\'confirm\');" />');                        
            CreateConfirmationPopup('confirm', 'Error', '<%=AppConstants.ERROR_MESSAGE %>');
        }
        function AddCommentToTheList(commentId)
        {   
            var container = $(_ReplyHyperLink).parent().parent().parent().find('.commentreplycontainer');
            var html = "<div class='replymessagecontainer'>"; 
            if(jQuery.trim($(container).html()).length == 0)
                html = "<div class='replymessagecontainer' style='margin-top:10px;'>";
            
            html += String.format("<div class='replymessageheading'>Reply of <b>{0}</b></div>", HtmlEncode(_UserFullName));
            html += FormatText('"'+_CommentReply.Message+'"')
            html += "</div>";
            //$(_ReplyHyperLink).parent().parent().parent().parent().find('.commentreplycontainer').append(html);
            
            container.append(html);            
        }
        function ToggleCollapse(element)
        {       
            var msgElement = $(element).parent().find('.replymessage');                
            var imgElement = $(element).find('img');
            if($(imgElement).attr('src').indexOf('plus.gif') > -1 ) //Is in Hidden Situation
            {
                $(imgElement).attr('src', '/Images/minus.gif').attr('alt', 'Collapse').attr('title', 'Collapse');
                $(msgElement).fadeIn();                    
            }
            else
            {
                $(imgElement).attr('src', '/Images/plus.gif').attr('alt', 'Expand').attr('title', 'Expand');
                $(msgElement).fadeOut();                    
            }            
        }
    </script>
    
<div id="divCommentingList">
    <div id="divEventCatcher">
        <div class="contentsubheading"><asp:Literal ID="ltrCommentHeading" runat="server"></asp:Literal></div>
        <div id="divCommentingTextBox" style="display:none;">    
            <asp:TextBox ID="txtComment" TextMode="MultiLine" MaxLength="2000" runat="server" style="width:350px; height:75px;"></asp:TextBox>
            <span id="spnValidationMessage" class="ErrorMessage" style="font-weight:normal;"><br />Please write a comment.</span>
            <div style="margin-top:5px; margin-bottom:10px;"><input type="button" value="Save Comment" class="ButtonCommon" onclick="SaveCommentData();" /></div>    
        </div>
    </div>
    <%--<div class="contentheading" id="divCommentListHeading" style="display:<%=_CommentListDisplayStyle %>;">Comments</div>--%>
    <asp:Repeater ID="rptCommentList" runat="server" onitemdatabound="rptCommentList_ItemDataBound">
        <ItemTemplate>
            <div>
                <div class="OddRowListing">
                    <div class="commentuserbox"><asp:Literal ID="ltrUserInfo" runat="server"></asp:Literal></div>
                    <div class="commentbox">
                        <div><asp:Literal ID="ltrComment" runat="server"></asp:Literal></div>
                        <div id="divReply" runat="server" visible="false" class="replylinkcontainer"><asp:HyperLink NavigateUrl="javascript:void(0);" ID="hplReply" runat="server">Reply</asp:HyperLink></div>
                        <div id="divCommentReplyes" class="commentreplycontainer" runat="server"></div>
                    </div>
                    <div class="commentboxforthumbs">
                        <asp:Literal ID="ltrThumbs" runat="server"></asp:Literal>
                        
                    </div>                
                    <div class="clearboth"></div>
                </div>                
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div>
                <div class="EvenRowListing">
                    <div class="commentuserbox"><asp:Literal ID="ltrUserInfo" runat="server"></asp:Literal></div>
                    <div class="commentbox">
                        <div> <asp:Literal ID="ltrComment" runat="server"></asp:Literal></div>
                        <div id="divReply" runat="server" visible="false" class="replylinkcontainer"><asp:HyperLink NavigateUrl="javascript:void(0);" ID="hplReply" runat="server">Reply</asp:HyperLink></div>
                        <div id="divCommentReplyes" class="commentreplycontainer" runat="server"></div>
                    </div>
                    <div class="commentboxforthumbs">
                        <asp:Literal ID="ltrThumbs" runat="server"></asp:Literal>
                    </div>
                    <div class="clearboth"></div>                
                </div>                
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>    
</div>