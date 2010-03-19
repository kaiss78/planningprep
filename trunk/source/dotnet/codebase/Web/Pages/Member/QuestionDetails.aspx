<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="QuestionDetails.aspx.cs" Inherits="Pages_Member_QuestionDetails" Title="Untitled Page" %>
<%@ Register src="~/UserControls/QuestionDetails.ascx" tagname="QuestionDetails" tagprefix="uc1" %>

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
    
    
    
    <%--Modal Popup Section Starts From Here--%>
    <div class="PopupContainer" id="confirm" style="display: none;">
        <div class="PopupHeader_111">            
            <div class="PopupHeaderMiddle">
                <div style="float: left;" id="popupHeader"><%--The Popup Title Will be shown here--%></div>
                <div style="float: right;">
                    <img src="/Images/btn/btn_popup_close.gif" onclick="HideConfirmationPopup('confirm');"
                        alt="Close" border="0" align="right" title="Close" style="margin-top: 2px; cursor: pointer;" />
                </div>                
                <div class="clearfloating"></div>
            </div>            
        </div>
        <div class="PopupBody">
            <span id="popupMessage"><%--The Message will be shown here--%></span>                        
        </div>
        <div class="PopupButtonContainer">
            <input type="button" value="Ok" class="ButtonCommon" style="padding-right:0px; width:55px;" onclick="HideConfirmationPopup('confirm');" />            
        </div>
    </div>
    <%--Modal Popup Section Ends Here--%>
</asp:Content>
