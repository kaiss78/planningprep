<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RateQuestion.ascx.cs"
    Inherits="UserControls_RateQuestion" %>   
    
    
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">        
        <Services>
            <asp:ServiceReference Path="~/Services/AjaxService.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    
    <script language="javascript" type="text/javascript">
        function GetData()
        {
            AjaxService.HelloWorld(success, failure);
        }
        function success(result)
        {
            alert(result);
        }
        function failure(error)
        {
            alert(error.get_message());
        }
    </script>    
    
<div runat="server" id="divRate">
<b>Rate This Question</b>
    <asp:RadioButtonList ID="rdoRating" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Text="1" Value="1"></asp:ListItem>
        <asp:ListItem Text="2" Value="2"></asp:ListItem>
        <asp:ListItem Text="3" Value="3"></asp:ListItem>
        <asp:ListItem Text="4" Value="4"></asp:ListItem>
        <asp:ListItem Text="5" Value="5"></asp:ListItem>
    </asp:RadioButtonList> 
    <asp:Button ID="btnSubmitRate" runat="server" Text="Rate" CssClass="ButtonCommon" style="width:auto;" onclick="btnSubmitRate_Click" /> <input type="button" value="Test" onclick="GetData();" />
<p>
    Why Rate? Questions with lower ratings are improved or removed, and questions with
    higher ratings receive a higher priority within the pool of questions."
</p>
</div>
<div runat="server" id="divRated">
    <b>Thanks for Rating This Question</b>
</div>
