<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Questions.aspx.cs" Inherits="Pages_Member_Questions" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <div>
        <p class="contentheading">
            All Questions</p>
        <p>
            To see a complete list of all questions in our database, select view all links below.</p>
        <p>
            <asp:HyperLink ID="hlinkAllQuestions" runat="server" NavigateUrl="QuestionList.aspx?ViewAll=1">View all Questions</asp:HyperLink></p>
    </div>
    <div>
        <p class="contentheading">
            Search for a Question By Keyword</p>
        <p>
            To search for question by keyword, simply type in the word in the place below and
            hit Go.</p>
        <div>
            <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" CssClass="ButtonCommon" runat="server" Text="Go" onclick="btnSearch_Click" /></div>
    </div>
    <div>
        <p class="contentheading">
            Search for a Question By Category</p>
        <p>
            To see questions that pertain to a certain category, simply select the category
            from the drop down box and hit Go.</p>
        <div>
            <asp:DropDownList ID="ddlQuestionCategory" runat="server">
                <asp:ListItem Text="Select Category" Selected="True" Value="None"></asp:ListItem>
                <asp:ListItem Text="History, Theory and Law" Value="HistoryTheoryLaw"></asp:ListItem>
                <asp:ListItem Text="Trends & Issues" Value="TrendsIssues"></asp:ListItem>
                <asp:ListItem Text="Plan Making" Value="PlanMaking"></asp:ListItem>
                <asp:ListItem Text="Functional Topics" Value="FunctionalTopics"></asp:ListItem>
                <asp:ListItem Text="Plan Implementation" Value="PlanImplementation"></asp:ListItem>
                <asp:ListItem Text="Ethics" Value="Ethics"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnSearchCategory"  CssClass="ButtonCommon" onclick="btnSearchCategory_Click" runat="server" Text="Go" />
        </div>
    </div>
    <div>
    </div>
</asp:Content>
