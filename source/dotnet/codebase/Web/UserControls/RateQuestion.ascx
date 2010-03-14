<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RateQuestion.ascx.cs"
    Inherits="UserControls_RateQuestion" %>
<div runat="server" id="divRate">
<b>Rate This Question</b>
    <asp:RadioButtonList ID="rdoRating" runat="server" RepeatDirection="Horizontal">
    <asp:ListItem Text="1" Value="1"></asp:ListItem>
    <asp:ListItem Text="2" Value="2"></asp:ListItem>
    <asp:ListItem Text="3" Value="3"></asp:ListItem>
    <asp:ListItem Text="4" Value="4"></asp:ListItem>
    <asp:ListItem Text="5" Value="5"></asp:ListItem>
    </asp:RadioButtonList>
<p>
    Why Rate? Questions with lower ratings are improved or removed, and questions with
    higher ratings receive a higher priority within the pool of questions."
</p>
</div>
<div runat="server" id="divRated">
    <b>Thanks for Rating This Question</b>
</div>
