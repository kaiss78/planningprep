﻿<%@ Page Language="C#" MasterPageFile="~/Pages/Member/MasterPageMember.master" AutoEventWireup="true"
    CodeFile="QuestionDetails.aspx.cs" Inherits="Pages_Member_QuestionDetails" Title="Untitled Page" %>
<%@ Register src="~/UserControls/QuestionDetails.ascx" tagname="QuestionDetails" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
   
    <uc1:QuestionDetails ID="questionDetails" runat="server" />
   
</asp:Content>
