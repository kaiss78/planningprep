<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Chart.ascx.cs" Inherits="UserControls_Chart" %>

<div style="border:#000000 1px solid; width:222px; height:233px;">
    <table style="border-collapse: collapse; width:222px; height:197px; background-image:url(/Images/chartback.gif); border:none;">
        <tr>
	        <td width="5" valign="bottom"><img border="0" src="/Images/spacer.gif" width="2" height="197"/></td>
	        <td width="40" valign="bottom" align="center" border="0"><img border="0" src="/Images/transparentbar.gif" width="40" style="height:<%=ConvertPercentageToPixel(1 - PercentageOfA).ToString()%>px;"/><img border="0" src="/Images/redbar.gif" width="40" style="height:<%=ConvertPercentageToPixel(PercentageOfA).ToString()%>px;"/></td>
	        <td width="5" valign="bottom"><img border="0" src="/Images/spacer.gif" width="2" height="197"></td>
	        <td width="40" valign="bottom" align="center" border="0"><img border="0" src="/Images/transparentbar.gif" width="40" style="height:<%=ConvertPercentageToPixel(1 - PercentageOfB).ToString()%>px;"/><img border="0" src="/Images/redbar.gif" width="40" style="height:<%=ConvertPercentageToPixel(PercentageOfB).ToString()%>px;"/></td>
	        <td width="5" valign="bottom"><img border="0" src="/Images/spacer.gif" width="2" height="197"></td>
	        <td width="40" valign="bottom" align="center" border="0"><img border="0" src="/Images/transparentbar.gif" width="40" style="height:<%=ConvertPercentageToPixel(1 - PercentageOfC).ToString()%>px;"/><img border="0" src="/Images/redbar.gif" width="40" style="height:<%=ConvertPercentageToPixel(PercentageOfC).ToString()%>px;"/></td>
	        <td width="5" valign="bottom"><img border="0" src="/Images/spacer.gif" width="2" height="197"></td>
	        <td width="40" valign="bottom" align="center" border="0"><img border="0" src="/Images/transparentbar.gif" width="40" style="height:<%=ConvertPercentageToPixel(1 - PercentageOfD).ToString()%>px;"/><img border="0" src="/Images/redbar.gif" width="40" style="height:<%=ConvertPercentageToPixel(PercentageOfD).ToString()%>px;"/></td>
	    </tr>
	    <tr>
	        <td style="height:32px;">&nbsp;</td>
	        <td align="center"><b>A</b><br/><%=FormatPercent(PercentageOfA).ToString()%>%</td>
	        <td>&nbsp;</td>
	        <td align="center"><b>B</b><br/><%=FormatPercent(PercentageOfB).ToString()%>%</td>
	        <td>&nbsp;</td>
	        <td align="center"><b>C</b><br/><%=FormatPercent(PercentageOfC).ToString()%>%</td>
	        <td>&nbsp;</td>
	        <td align="center"><b>D</b><br/><%=FormatPercent(PercentageOfD).ToString()%>%</td>
	    </tr>
    </table>
</div>

<div style="margin-top:15px;"><b>*Based on <%=TotalResponse.ToString()%> responses.</b></div>

<%--<p class="question">--%>
