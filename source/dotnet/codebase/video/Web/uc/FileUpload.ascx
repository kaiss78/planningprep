<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUpload.ascx.cs" Inherits="uc_FileUpload" %>


<!-- create special form for uploading files -->

    <table width="400" cellpadding="4" bgcolor="silver">
        <tr>
            <td valign="top" width="100">
                <span id="upSpan" runat="server"/>
            </td>
            <td valign="top" >
                <input type="file" id="filename" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top" >
                <span id="statusSpan" runat="server"/>
            </td>
            <td valign="top" >
                <span id="status" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top" >
                &nbsp;
            </td>
            <td valign="top" >
                <input type=button id="uploadBtn" 
                    OnServerClick="uploadBtn_Click" 
                    runat="server" />    
            </td>
        </tr>
    </table> 



