<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Chapters.ascx.cs" Inherits="uc_Chapters" %>

<script type='text/javascript' src='http://ec.europa.eu/wel/players/jwflvplayer/swfobject.js'></script>

<script type='text/javascript' src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<br /><br />
<div runat="server" id="divChapters" style="width: 400px;margin-left:20px;" class="fl">
</div>
<div id="divVideo" style="display: block; float: left">
    <div id="videoPanel" style="display: none">
        Multiple play mode is <strong><span id="spnMode">ON</span></strong>&nbsp;&nbsp;<input
            id="btnPlayMode" type="button" value="Switch to play single mode" />&nbsp;&nbsp;<input
                id="btnNewWindow" type="button" value="View in new window" />
        <br />
        <br />
    </div>
    <div id="preview1">
        The player will show in this div</div>
</div>
<div class="clearBoth">
</div>

<script language="javascript">

$(document).ready(function(){

var videoUrl = '';//'&file=http://webtools.ec.europa.eu/flash-player/examples/playlist.xml&playlist=right&playlistsize=200&duration=224';

$("#btnNewWindow").click(function(){

$("#divVideo").css("display","block");
$("#videoPanel").css("display","none");
setVideoUrl('');
    
    window.open("WatchVideo.aspx?ItemNumber=" + currentItemNo,"mywin","width=600,height=500,resizable =no,screenX=50,left=50,screenY=50,top=50,status=no,menubar=no");
});
$("#btnPlayMode").click(function(){
    
    if($(this).val() == "Switch to play single mode")
    {
        $(this).val("Switch to play multiple mode");
        var videoUrl = '&file=' + currentUrl + '&playlist=right&playlistsize=200&duration=224';
        $("#spnMode").text("OFF");
    }
    else
    {
        $(this).val("Switch to play single mode");
        var videoUrl = '&file=' + currentUrl + '&playlist=right&playlistsize=200&duration=224&repeat=list&autostart=true';
        $("#spnMode").text("ON");
    }
   setVideoUrl(videoUrl);
});

setVideoUrl(videoUrl);

 });
 
function setVideoUrl(currentChapter)
{
    
    var s1 = new SWFObject('http://ec.europa.eu/wel/players/jwflvplayer/player.swf','player','600','400','9');

	s1.addParam('allowfullscreen','true');
	s1.addParam('allowscriptaccess','always');
	s1.addParam('allownetworking','all');
	s1.addParam('wmode','opaque');

    s1.addParam('flashvars',currentChapter);
	s1.write('preview1');
	
}
var currentUrl;
var currentItemNo;

function runVideo(itemUrl,itemNo)
{
    currentUrl = itemUrl;
    currentItemNo = itemNo;
    
    $("#divVideo").css("display","block");
    $("#videoPanel").css("display","block");
    
    var videoUrl = '&file=' + itemUrl + '&playlist=right&playlistsize=200&duration=224&repeat=list&autostart=true';
    setVideoUrl(videoUrl);
}
</script>

