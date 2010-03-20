<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModalMessage.ascx.cs" Inherits="UserControls_ModalMessage" %>

<%--To work this user control properly, add a reference to the /CSS/ModalPopup.css Style Sheet--%>  

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