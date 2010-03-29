<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUpload.ascx.cs" Inherits="uc_FileUpload" %>


<!-- create special form for uploading files -->
<fieldset style="width:400px">
<legend><strong>Upload Exel file</strong></legend>
    <table width="400" cellpadding="4">
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
                Status
            </td>
            <td valign="top" >
                <span id="status" runat="server"></span>   
            </td>
        </tr>
        <tr>
            <td valign="top" >
                &nbsp;
            </td>
            <td valign="top" >
                <input type=button class="ButtonCommon" id="uploadBtn" 
                    OnServerClick="uploadBtn_Click" 
                    runat="server" />    
            </td>
        </tr>
    </table> 
</fieldset>



