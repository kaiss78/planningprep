<%@ Page Language="C#" MasterPageFile="~/Pages/Public/MasterPagePublic.master" AutoEventWireup="true" CodeFile="AnswerOfTheWeekMessage.aspx.cs" Inherits="Pages_Public_AnswerOfTheWeekMessage" Title="Untitled Page" %>

<%@ Register src="/UserControls/Chart.ascx" TagName="Chart" TagPrefix="Chart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    
    <div class="contentheading">Question of the Week</div>
    <div class="homepagecontentbox">
        <div style="font-weight:bold;"><asp:Literal ID="ltrQuestion" runat="server"></asp:Literal></div>
        <div style="margin: 15px 0px 15px 0px;"><asp:Literal ID="ltrAnswer" runat="server"></asp:Literal></div>        
        
        <div><asp:Literal ID="ltrExplanation" runat="server"></asp:Literal></div>
        <div style="margin-top:15px;">
            More information on this topic can be found at these sites:
            <div style="margin-top:15px;">
                <asp:Literal ID="ltrLinks" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="homepagecontentbox">
        <Chart:Chart ID="ucChart" runat="server" />
    </div>
    <div class="clearfloating"></div>
    
    
    
    
</asp:Content>

