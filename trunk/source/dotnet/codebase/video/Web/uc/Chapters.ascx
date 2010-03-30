<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Chapters.ascx.cs" Inherits="uc_Chapters" %>

<script type='text/javascript' src='http://ec.europa.eu/wel/players/jwflvplayer/swfobject.js'></script>

<fieldset style="width:435px;" class="fl">
<legend><strong>Video chapters</strong></legend>
<div style="padding-left:10px;padding-top:10px;float:left">
<a href="javascript:void(0)" onclick="expandAll();" style="text-decoration:none"><strong>+<span style="padding-left:10px">Show All</span></strong></a>&nbsp;&nbsp;<a href="javascript:void(0)" style="text-decoration:none" onclick="closeAll();"><strong>- <span "padding-left:10px">Close All</span></strong></a>
</div>
<div class="fr" style="padding-left:10px;padding-top:10px;"><strong>Duration(mm:ss)</strong></div>
<div class="clearBoth"></div>
<div runat="server" style="padding:10px" id="divChapters" 
>

</div>
</fieldset>
<div id="divVideo" style="display: block; float: left;margin-left:20px;padding-top:6px;">
    <div id="videoPanel" style="display: none">
        Multiple play mode is <strong><span id="spnMode">ON</span></strong>&nbsp;&nbsp;<input
            id="btnPlayMode" type="button" class="ButtonCommon" value="Play single mode" />&nbsp;&nbsp;<input
                id="btnNewWindow" type="button" class="ButtonCommon" value="New window" />
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

var videoUrl = '';//'&file=http://webtools.ec.europa.eu/flash-player/examples/playlist.xml&playlistsize=200&duration=224';

$("#btnNewWindow").click(function(){

$("#divVideo").css("display","block");
$("#videoPanel").css("display","none");
setVideoUrl('');
    
    window.open("WatchVideo.aspx?ItemNumber=" + currentItemNo,"mywin","width=640,height=480,resizable =yes,screenX=50,left=50,screenY=50,top=50,status=no,menubar=no");
});
$("#btnPlayMode").click(function(){
    
    if($(this).val() == "Play single mode")
    {
        $(this).val("Play multiple mode");
        var videoUrl = '&file=' + currentUrl + '&playlistsize=200&duration=224';
        $("#spnMode").text("OFF");
    }
    else
    {
        $(this).val("Play single mode");
        var videoUrl = '&file=' + currentUrl + '&playlistsize=200&duration=224&repeat=list&autostart=true';
        $("#spnMode").text("ON");
    }
   setVideoUrl(videoUrl);
});

setVideoUrl(videoUrl);

 });

function closeAll()
{
    $("div[childrenId]").fadeOut(100);
    $(".expandCollapseDiv").text("+");
}

function expandAll()
{
    $("div[childrenId]").fadeIn(100);
    $(".expandCollapseDiv").text("-");
}
 
function setVideoUrl(currentChapter)
{
    
    var s1 = new SWFObject('http://ec.europa.eu/wel/players/jwflvplayer/player.swf','player','400','370','9');

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
    
    var videoUrl = '&file=' + itemUrl + '&playlistsize=200&duration=224&repeat=list&autostart=true';
    setVideoUrl(videoUrl);
}
</script>

