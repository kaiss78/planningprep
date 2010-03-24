<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LinkToComment.aspx.cs" Inherits="LinkToComment" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript">
        function DisableButton(btnElement)
        {
            $(btnElement).attr('disabled', 'disabled');
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div style="margin-top:55px;">
        <div id="divMessage" runat="server" style="margin-bottom:10px;"></div>
        <asp:Button ID="btnImportLinks" runat="server" Text="Import Links to Comment" OnClick="btnImportLinks_Click"/>
    </div>
</asp:Content>

