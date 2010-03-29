﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WatchVideo.ascx.cs" Inherits="uc_WatchVideo" %>

<script language="javascript">

$(document).ready(function(){
var videoUrl = '&file=<%=ChapterUrl %>&playlist=right&playlistsize=200&duration=224&repeat=list&autostart=true';
$("#btnPlayMode").click(function(){
    
    if($(this).val() == "Play single mode")
    {
        $(this).val("Play multiple mode");
        var videoUrl = '&file=<%=ChapterUrl %>&playlist=right&playlistsize=200&duration=224';
        $("#spnMode").text("OFF");
    }
    else
    {
        $(this).val("Play single mode");
        var videoUrl = '&file=<%=ChapterUrl %>&playlist=right&playlistsize=200&duration=224&repeat=list&autostart=true';
        $("#spnMode").text("ON");
    }
    setVideoUrl(videoUrl);
});
//var videoUrl = '&file=http://webtools.ec.europa.eu/flash-player/examples/playlist.xml&playlist=right&playlistsize=200&duration=224'
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
</script>

Multiple play mode is <strong><span id="spnMode">ON</span></strong>&nbsp;&nbsp;<input class="ButtonCommon" id="btnPlayMode" type="button" value="Play single mode" />
<br /><br />
<div id="preview1">
    The player will show in this div</div>
