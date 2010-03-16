<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="QuestionDetails.aspx.cs" Inherits="Pages_Member_QuestionDetails" Title="Untitled Page" %>
<%@ Register src="~/UserControls/QuestionDetails.ascx" tagname="QuestionDetails" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/CSS/ModalPopup.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
   
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>   
    
    <uc1:QuestionDetails ID="questionDetails" runat="server" />
    
    <%--Modal Popup Section Starts From Here--%>
    <div class="yellowPopupContainer" id="confirm" style="display: none;">
        <div class="yellowPopupHeader">
            <div class="yellowPopupHeaderLeft">
            </div>
            <div class="yellowPopupHeaderMiddle">
                <div style="float: left;" id="popupHeader"><%--The Popup Title Will be shown here--%></div>
                <div style="float: right;">
                    <img src="/Images/btn/btnClose_popup.gif" onclick="HideConfirmationPopup('confirm');"
                        alt="Close" border="0" align="right" title="Close" style="margin-top: 2px; cursor: pointer;" />
                </div>                
                <div class="clearfloating"></div>
            </div>
            <div class="yellowPopupHeaderRight">
            </div>
            <div class="clearfloating"></div>
        </div>
        <div class="yellowPopupBody" style="padding-bottom: 20px">
            <span id="popupMessage"><%--The Message will be shown here--%></span>            
            <div class="btnYellowPopup">
                <a href="javascript:void(0);" onclick="HideConfirmationPopup('confirm');">
                    <img border="0" title="Ok" src="/Images/btn/btnOk.png" alt="Ok" class="btnAllForPopup" />
                </a>                
            </div>
        </div>
    </div>
    <%--Modal Popup Section Ends Here--%>
</asp:Content>
