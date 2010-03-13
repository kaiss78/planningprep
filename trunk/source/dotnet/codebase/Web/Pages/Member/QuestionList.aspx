<%@ Page Language="C#" MasterPageFile="~/Pages/Member/MasterPageMember.master" AutoEventWireup="true" CodeFile="QuestionList.aspx.cs" Inherits="Member_QuestionList" Title="Untitled Page" %>

<%@ Register src="../../UserControls/PaginatedQuestions.ascx" tagname="PaginatedQuestions" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <uc1:PaginatedQuestions ID="PaginatedQuestions1" ShowDetailsLink="true" ShowEditLink="false" ShowLastModifiedDate="false" runat="server" />
</asp:Content>

