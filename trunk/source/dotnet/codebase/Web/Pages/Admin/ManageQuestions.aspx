<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageQuestions.aspx.cs" Inherits="Admin_ManageQuestions" Title="Untitled Page" %>

<%@ Register src="/UserControls/PaginatedQuestions.ascx" tagname="PaginatedQuestions" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">

    <div style="float:right;"><asp:HyperLink ID="hplAddNewQuestion" runat="server">Add New Question</asp:HyperLink></div>
    <div class="clearfloating"></div>
    <uc1:PaginatedQuestions ID="PaginatedQuestions1" ShowQuestionTitle="true" ShowDetailsLink="true" ShowEditLink="true" ShowLastModifiedDate="true" AnswerQuestion="false" ShowQuestionsForAnswerMode="false" runat="server" />

</asp:Content>

