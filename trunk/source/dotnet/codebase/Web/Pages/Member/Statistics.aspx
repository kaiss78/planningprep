<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Statistics.aspx.cs" Inherits="Pages_Member_Statistics" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .categorycontainer
        {
        	margin-top:15px;
        	padding-bottom:15px;
        	border-bottom: solid 1px #C0C0C0;
        }
        .statisticscontainer
        {
        	margin-top:15px;
        	/*padding-bottom:15px;
        	border-bottom: solid 1px #C0C0C0;*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="contentheading" id="divHeading" runat="server">Your Statistics Since Joining</div>    
    <%--Left Containter--%>
    <div class="homepagecontentbox">
        <div style="margin-bottom:15px;"><b>Overall Statistics</b></div>        
        <div class="statisticscontainer">
            <b>Username</b><br />
            <asp:Literal ID="ltrUserName" runat="server"></asp:Literal>
        </div>
        <div class="statisticscontainer">
            <b>Full Name</b><br />
            <asp:Literal ID="ltrFullName" runat="server"></asp:Literal>
        </div>
        <div class="statisticscontainer">
            <b>Email</b><br />
            <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
        </div>
        <div class="statisticscontainer">
            <b>Last Login</b><br />
            <asp:Literal ID="ltrLastLogin" runat="server"></asp:Literal>
        </div>
        <div class="statisticscontainer">
            <b># of Logins</b><br />
            <asp:Literal ID="ltrNumberOfLogin" runat="server"></asp:Literal>
        </div>
        <div class="statisticscontainer">
            <b>Questions Taken</b><br />
            <asp:Literal ID="ltrQuestionsTaken" runat="server"></asp:Literal>
        </div>
        <div class="statisticscontainer">
            <b>Number of Correct Answers</b><br />
            <asp:Literal ID="ltrCorrectAnswers" runat="server"></asp:Literal>
        </div>
        <div class="statisticscontainer">
            <b>Percent Correct</b><br />
            <asp:Literal ID="ltrPercentCorrect" runat="server"></asp:Literal>
        </div>
        <div class="statisticscontainer">
            <b>Total Time (in seconds)</b><br />
            <asp:Literal ID="ltrTotalTime" runat="server"></asp:Literal>
        </div>
        <div class="statisticscontainer">
            <b>Time Per Question (in seconds)</b><br />
            <asp:Literal ID="ltrTimePerQuestion" runat="server"></asp:Literal>
        </div>     
        <div class="statisticscontainer">
            Use the tool below to view your statistics from a specific date forward. This is a great way to 
            see what kind of progress you have been making.  Select a date below and press Filter.     
            <div style="margin-top:10px;">
                <asp:DropDownList ID="ddlMonth" CssClass="DropDownListCommon" runat="server" style="width:auto;">
                    <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                    <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                </asp:DropDownList>
            
            
                <asp:DropDownList ID="ddlDay" CssClass="DropDownListCommon" runat="server" style="width:auto;"></asp:DropDownList>
                <asp:DropDownList ID="ddlYear" CssClass="DropDownListCommon" runat="server" style="width:auto;"></asp:DropDownList>
                <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="ButtonCommon" OnClick="btnFilter_Click" />                
            </div>
        </div>
    </div>
    
    <%--Right Container--%>
    <div class="homepagecontentbox" style="width:300px;">
        <div style="margin-bottom:15px;"><b>Statistics By Category</b></div>
        <div id="divCategoryContainer" runat="server"></div>        
    </div>
    <div class="clearfloating"></div>
</asp:Content>

