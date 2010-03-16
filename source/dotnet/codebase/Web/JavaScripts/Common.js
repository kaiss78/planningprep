function HtmlEncode(text)
{
    return text.replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;')
}

function FormatText(text)
{
    return HtmlEncode(text).replace(/\n/g, '<br />');
}
function GetLogicalText(count, textToUse)
{
    if (count > 1)
        return String.format("+{0} {1}s", count, textToUse);
    else if (count < -1)
        return String.format("{0} {1}s", count, textToUse);
    else if (count == 0)
        return String.format("0 {0}s", textToUse);
    else 
        return String.format("+1 {0}", textToUse);
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
    
    SetModalPopupPosition();
    SetTexts();
    $('#' + _PopupID).fadeIn('slow', null);
    CreteBlockingContainer();        
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
    return false;   
}
function hideBlocking()
{			
    $("#divBlockingContainer").css({'display' : 'none'});
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
        CreteBlockingContainer();        
}
jQuery.fn.Center = function() {
    this.css("position", "absolute");    
    this.css("top", ($(window).height() - this.height()) / 2 + $(window).scrollTop() + "px");
    this.css("left", ($(window).width() - this.width()) / 2 + $(window).scrollLeft() + "px");    
    return this;
}
/*Modal Popup Section Ends*/