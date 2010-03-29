<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="UploadFile.aspx.cs" Inherits="_UploadFile" %>

<%@ Register TagPrefix="era" TagName="upload" Src="~/uc/FileUpload.ascx" %>
<%@ Register TagPrefix="era" TagName="chapterFiles" Src="~/uc/ChapterDefinitionFileList.ascx" %>

<asp:Content ContentPlaceHolderID="BodyContents" ID="Content1" runat="server">
    <div class="fl">
        <era:chapterFiles ID="chapterFileList" uploadText="Select File:" runat="server" />
    </div>
    <div class="fl" style="margin-left:20px">
        <era:upload ID="myControl" uploadText="Select File:" runat="server" />
    </div>
    <div class="clearBoth"></div>
    
</asp:Content>
