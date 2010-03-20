<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="QuestionDetails.aspx.cs" Inherits="Pages_Member_QuestionDetails" Title="Untitled Page" %>
    
<%@ Register src="/UserControls/QuestionDetails.ascx" tagname="QuestionDetails" tagprefix="uc1" %>
<%@ Register Src="/UserControls/ModalMessage.ascx" TagName="ModalMessage" TagPrefix="UC" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/CSS/ModalPopup.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
   
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>   
    
    <uc1:QuestionDetails ID="questionDetails" runat="server" />

    <%--<input type="button" value="Show Modal" onclick="CreateConfirmationPopup('confirm', 'Error', '<%=AppConstants.ERROR_MESSAGE %>');" />    
    
    <div class="homepagecontentbox">
        asdfsad fsdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf 
        sdaf sdaf sadf sadf sdaf sdaf sdaf sdaf sdafsdafsadfsadf
        sdaf sadf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf ds
        sdaf sadf sdafsdafsadfsdafsdaf sdaf sdafsdaf sdafsadf sdaf
        sdaf sadf sdafsdafsdafsdafsdafsdaf sadfsdafsdafsdaf sdaf sdaf
        sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdafsad sdfsd
        asdfsad fsdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf 
        sdaf sdaf sadf sadf sdaf sdaf sdaf sdaf sdafsdafsadfsadf
        sdaf sadf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf ds
        sdaf sadf sdafsdafsadfsdafsdaf sdaf sdafsdaf sdafsadf sdaf
        sdaf sadf sdafsdafsdafsdafsdafsdaf sadfsdafsdafsdaf sdaf sdaf
        sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdafsad sdfsd
        asdfsad fsdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf 
        sdaf sdaf sadf sadf sdaf sdaf sdaf sdaf sdafsdafsadfsadf
        sdaf sadf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf ds
        sdaf sadf sdafsdafsadfsdafsdaf sdaf sdafsdaf sdafsadf sdaf
        sdaf sadf sdafsdafsdafsdafsdafsdaf sadfsdafsdafsdaf sdaf sdaf
        sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdafsad sdfsd
        asdfsad fsdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf 
        sdaf sdaf sadf sadf sdaf sdaf sdaf sdaf sdafsdafsadfsadf
        sdaf sadf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf ds
        sdaf sadf sdafsdafsadfsdafsdaf sdaf sdafsdaf sdafsadf sdaf
        sdaf sadf sdafsdafsdafsdafsdafsdaf sadfsdafsdafsdaf sdaf sdaf
        sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdafsad sdfsd
    </div>
    <div class="homepagecontentbox">
        asdfsad fsdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf 
        sdaf sdaf sadf sadf sdaf sdaf sdaf sdaf sdafsdafsadfsadf
        sdaf sadf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf ds
        sdaf sadf sdafsdafsadfsdafsdaf sdaf sdafsdaf sdafsadf sdaf
        sdaf sadf sdafsdafsdafsdafsdafsdaf sadfsdafsdafsdaf sdaf sdaf
        sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdafsad sdfsd
        asdfsad fsdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf 
        sdaf sdaf sadf sadf sdaf sdaf sdaf sdaf sdafsdafsadfsadf
        sdaf sadf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf ds
        sdaf sadf sdafsdafsadfsdafsdaf sdaf sdafsdaf sdafsadf sdaf
        sdaf sadf sdafsdafsdafsdafsdafsdaf sadfsdafsdafsdaf sdaf sdaf
        sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdafsad sdfsd
        asdfsad fsdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf 
        sdaf sdaf sadf sadf sdaf sdaf sdaf sdaf sdafsdafsadfsadf
        sdaf sadf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf ds
        sdaf sadf sdafsdafsadfsdafsdaf sdaf sdafsdaf sdafsadf sdaf
        sdaf sadf sdafsdafsdafsdafsdafsdaf sadfsdafsdafsdaf sdaf sdaf
        sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdafsad sdfsd
        asdfsad fsdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf 
        sdaf sdaf sadf sadf sdaf sdaf sdaf sdaf sdafsdafsadfsadf
        sdaf sadf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf ds
        sdaf sadf sdafsdafsadfsdafsdaf sdaf sdafsdaf sdafsadf sdaf
        sdaf sadf sdafsdafsdafsdafsdafsdaf sadfsdafsdafsdaf sdaf sdaf
        sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdaf sdafsad sdfsd
    </div>
    <div class="clearfloating"></div>--%>
    
    <UC:ModalMessage ID="ucModalMessage" runat="server" />
    
</asp:Content>
