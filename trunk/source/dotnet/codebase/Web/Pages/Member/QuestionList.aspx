<%@ Page Language="C#" MasterPageFile="~/Pages/Member/MasterPageMember.master" AutoEventWireup="true"
    CodeFile="QuestionList.aspx.cs" Inherits="Member_QuestionList" Title="Untitled Page" %>

<%@ Register Src="../../UserControls/PaginatedQuestions.ascx" TagName="PaginatedQuestions"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <div runat="server" id="divViewAll">
        <p class="contentheading">
            All Questions</p>
        <p>
            Listed below are the questions in our database. There are 702 questions in this
            list. Simply click on a question you would like to take. Your question filter is
            currently set to ON (question filter applied). In this mode, you will not see the
            questions in our database that you have already answered. If you wish to view all
            questions, even the ones you have taken, you must make this change in your 
            <asp:HyperLink ID="hlinkUserProfile" runat="server" Text="user
            profile"></asp:HyperLink>.</p>
    </div>
    <uc1:PaginatedQuestions ID="PaginatedQuestions1" ShowDetailsLink="true" ShowEditLink="false"
        ShowLastModifiedDate="false" AnswerQuestion="true" runat="server" />
</asp:Content>
