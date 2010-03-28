<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="UploadFile.aspx.cs" Inherits="_UploadFile" %>

<%@ Register TagPrefix="era" TagName="upload" Src="~/uc/FileUpload.ascx" %>
<asp:Content ContentPlaceHolderID="BodyContents" ID="Content1" runat="server">
    <div>
        <era:upload ID="myControl" uploadText="Select File:" runat="server" />
    </div>
</asp:Content>
