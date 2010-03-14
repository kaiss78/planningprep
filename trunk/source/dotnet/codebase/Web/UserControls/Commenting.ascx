<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Commenting.ascx.cs" Inherits="UserControls_Commenting" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
        <asp:ServiceReference Path="~/Services/AjaxService.asmx" />
    </Services>
</asp:ScriptManager>   
    
    <script language="javascript" type="text/javascript">
        var _QuestionID = <%= _QuestionID.ToString()%>;
        var _UserID = <%= _UserID.ToString()%>;
        var _TotalCount = <%= _TotalCount.ToString()%>;
        var _Comment = new App.Models.Comments.Comment();
        function SaveCommentData()
        {   
            _Comment.CommentText = $('#txtComment').val();
            _Comment.UserID = _UserID;
            _Comment.QuestionID = _QuestionID;
            //comment.Rank = 0;
            
            AjaxService.SaveComment(_Comment, SaveComment_Success, SaveComment_Failiure);
        }        
        function SaveComment_Success(result)
        {
            var commentId = result;
            var className = (_TotalCount % 2) == 0 ? 'OddRowListing' : 'EvenRowListing';
            var domElement = '<div class="' + className + '">' + _Comment.CommentText;/// + '</div>';
            domElement += '<div><a href="javascript:void(0);" onclick="ThumbsUp(' + commentId + ');">Thumbs Up</a> <a href="javascript:void(0);" onclick="ThumbsDown(' + commentId + ');">Thumbs Down</a></div>';
            domElement += '</div>';
            $('#divCommentingList').append(domElement);            
            $('#txtComment').html('');
            _TotalCount++;
        }
        function SaveComment_Failiure(error)
        {
            alert(error.get_message());
        } 
        function ThumbsUp(commentID)
        {
            alert(commentID);
        }   
        function ThumbsDown(commentID)
        {
            alert(commentID);
        }
        
    </script>


<div id="divCommentingList">
    <asp:Repeater ID="rptCommentList" runat="server" onitemdatabound="rptCommentList_ItemDataBound">
        <ItemTemplate>
            <div class="OddRowListing">
                <div><asp:Literal ID="ltrComment" runat="server"></asp:Literal></div>
                <div><asp:Literal ID="ltrThumbs" runat="server"></asp:Literal></div>                
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="EvenRowListing">
                <div><asp:Literal ID="ltrComment" runat="server"></asp:Literal></div>
                <div><asp:Literal ID="ltrThumbs" runat="server"></asp:Literal></div>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>    
</div>

<div>
    <textarea id="txtComment"></textarea>
    <div><input type="button" value="Save Comment" onclick="SaveCommentData();" /></div>    
</div>

