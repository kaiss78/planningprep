function HtmlEncode(text)
{
    return text.replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;')
}
function FormatText(text)
{
    return HtmlEncode(text).replace(/\n/g, '<br />');
}
function GetRandomNumber()
{
    return Math.floor(Math.random() * 10000);
}
function GetLogicalText(count, textToUse)
{
    if (count > 1)
        return "+" + count + " " + textToUse + "s"
    else if(count < 0)
    {
        if(count == -1)
            return count + " " + textToUse;
        else// if (count < -1)
            return count + " " + textToUse+ "s";
    }    
    else if (count == 0)
        return "0 " + textToUse + "s";
    else 
        return "+1 " + textToUse;
}

/*Modal Popup Section Starts */
var _PopupID;
var _PopupTitle;
var _PopupMessage;

function CreateConfirmationPopup(popupId, title, message) 
{
    _PopupID = popupId,            
    _PopupTitle = title;
    _PopupMessage = message;
    
    //SetModalPopupPosition();
    SetTexts();
    $('#' + _PopupID).Center().fadeIn('slow', ShowShadowContainer);
    //ShowShadowContainer();
    //CreteBlockingContainer();   
    //ShowShadowContainer();     
} 
function SetTexts()
{
    $('#popupHeader').html(_PopupTitle);
    $('#popupMessage').html(_PopupMessage);
}
function HideConfirmationPopup() 
{       
    if(null == document.getElementById(_PopupID)) return;
    $('#' + _PopupID).fadeOut(500, hideBlocking);    
    $('#divShadow').fadeOut(500, RemoveShadeElement);            
    return false;   
}
function hideBlocking()
{			
    $("#divBlockingContainer").css({'display' : 'none'});
}
function RemoveShadeElement()
{ 
    $('#divShadow').remove(); 
    $('#divPopupButtonContainer').html('<input type="button" value="Ok" class="ButtonCommon" style="padding-right:0px; width:55px;" onclick="HideConfirmationPopup(\'confirm\');" />');
}
function CreteBlockingContainer() 
{
    var blockingConatiner;
    var hasCreatedEarlier = false;
    if (null != document.getElementById('divBlockingContainer')) {
        blockingConatiner = document.getElementById('divBlockingContainer');        
    }
    else {
        blockingConatiner = document.createElement('div');
        blockingConatiner.id = 'divBlockingContainer';
    }
    var documentHeight = $(document).height();
    var documentWidth = $(document).width();
    documentWidth = $.browser.msie ? (documentWidth - 22) : documentWidth;
    //documentHeight = $.browser.msie ? (documentHeight - 6) : documentHeight;
    //alert('Width: ' + documentWidth + ' height: ' + documentHeight);            
    blockingConatiner.style.position = 'absolute';
    blockingConatiner.style.width = documentWidth + 'px'; //document.body.clientWidth + 'px';
    blockingConatiner.style.height = documentHeight + 'px'; //document.body.clientHeight + 'px';
    blockingConatiner.style.left = 0 + 'px';
    blockingConatiner.style.top = 0 + 'px';
    blockingConatiner.style.zIndex = 19;
    blockingConatiner.className = 'blockingContainer';
    document.body.appendChild(blockingConatiner);
    blockingConatiner.style.display = '';    
}

///Reset the position of the Popup  
window.onresize = SetModalPopupPosition;

function SetModalPopupPosition()
{          
    if(null == document.getElementById(_PopupID)) return;
    $('#' + _PopupID).Center();
    if($('#' + _PopupID).is(':visible'))
    {        
        $('#divShadow').Center();        
        CreteBlockingContainer();                
    }
}

function ShowShadowContainer()
{
    if(null == document.getElementById(_PopupID)) return;
    var popup = $('#' + _PopupID);
    //var position = popup.position();
    var increaseValue = 8;
    //var domElement = String.format('<div id="divShadow" class="modalpopupshadow" style="width:{0}px; height:{1}px;">&nbsp;</div>', popup.width() + (increaseValue * 2), popup.height() + (increaseValue * 2));
    var domElement = '<div id="divShadow" class="modalpopupshadow" style="width:' + (popup.width() + (increaseValue * 2)) + 'px; height:' + (popup.height() + (increaseValue * 2)) + 'px;">&nbsp;</div>';
    popup.parent().append(domElement);
    $('#divShadow').Center().fadeIn('slow', CreteBlockingContainer);    
}

jQuery.fn.Center = function() {
    //this.css("position", "absolute");    
    this.css("top", ($(window).height() - this.height()) / 2 + $(window).scrollTop() + "px");
    this.css("left", ($(window).width() - this.width()) / 2 + $(window).scrollLeft() + "px");    
    return this;
}
/*Modal Popup Section Ends*/