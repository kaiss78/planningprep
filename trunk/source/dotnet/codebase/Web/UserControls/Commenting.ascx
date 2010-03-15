<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Commenting.ascx.cs" Inherits="UserControls_Commenting" %>

    <style type="text/css">
        .OddRowListing, .EvenRowListing
        {
    	    min-height:40px;
    	    padding-bottom:10px;
    	    height:auto;
        }
    </style>    
    
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">        
        <Services>
            <asp:ServiceReference Path="~/Services/AjaxService.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    
    <script language="javascript" type="text/javascript">
        var _QuestionID = <%= _QuestionID.ToString()%>;
        var _UserID = <%= _UserID.ToString()%>;
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
            var domElement = '<div class="' + className + '"><div class="commentbox">' + FormatText(_Comment.CommentText) + '</div>';
            //domElement += '<div class="commentboxforthumbs"><a href="javascript:void(0);" onclick="ThumbsUp(' + commentId + ');">Thumbs Up</a><br/><a href="javascript:void(0);" onclick="ThumbsDown(' + commentId + ');">Thumbs Down</a></div>';
            domElement += '<div class="commentboxforthumbs">Thumbs Up<br/>Thumbs Down</div>';
            domElement += '<div class="clearboth"></div>';
            domElement += '</div>';
                        
            if(_TotalCount == 0)               
                $('#divCommentListHeading').show();
                
            $('#divCommentingList').append(domElement);            
            $('#<%=txtComment.ClientID%>').val('');
            _TotalCount++;
            ToggleCommentingBox();
        }
        function SaveComment_Failiure(error)
        {
            alert(error.get_message());
        }
        
        ///Thumbs Up and Down 
        function ThumbsUp(commentID)
        {
            AjaxService.CommentThumbsUp(commentID, CommentThumbsUp_Success, CommentThumbsUp_Failiure);
        }
        function CommentThumbsUp_Success(result)
        {
            alert('Your preference saved successfully.');
        }
        function CommentThumbsUp_Failiure(error)
        {
            alert(error.get_message());
        }   
        function ThumbsDown(commentID)
        {
            AjaxService.CommentThumbsDown(commentID, CommentThumbsDown_Success, CommentThumbsDown_Failiure);
        }        
        function CommentThumbsDown_Success(result)
        {
            alert('Your preference saved successfully.');   
        }
        function CommentThumbsDown_Failiure(error)
        {
            alert(error.get_message());
        }   
        
        function ToggleCommentingBox() 
        {
            if($('#divCommentingTextBox').is(':visible'))
                $('#divCommentingTextBox').fadeOut();
            else
                $('#divCommentingTextBox').fadeIn();
                
        }
    </script>


<div id="divCommentingList">
    <div class="contentheading" id="divCommentListHeading" style="display:<%=_CommentListDisplayStyle %>;">Comments</div>
    <asp:Repeater ID="rptCommentList" runat="server" onitemdatabound="rptCommentList_ItemDataBound">
        <ItemTemplate>
            <div class="OddRowListing">
                <div class="commentbox"><asp:Literal ID="ltrComment" runat="server"></asp:Literal></div>
                <div class="commentboxforthumbs"><asp:Literal ID="ltrThumbs" runat="server"></asp:Literal></div>                
                <div class="clearboth"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="EvenRowListing">
                <div class="commentbox"><asp:Literal ID="ltrComment" runat="server"></asp:Literal></div>
                <div class="commentboxforthumbs"><asp:Literal ID="ltrThumbs" runat="server"></asp:Literal></div>
                <div class="clearboth"></div>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>    
</div>

<div class="contentheading"><asp:Literal ID="ltrCommentHeading" runat="server"></asp:Literal></div>
<div id="divCommentingTextBox" style="display:none;">    
    <asp:TextBox ID="txtComment" TextMode="MultiLine" MaxLength="2000" runat="server" style="width:350px; height:75px;"></asp:TextBox>
    <div style="margin-top:10px;"><input type="button" value="Save Comment" class="ButtonCommon" onclick="SaveCommentData();" /></div>    
</div>

