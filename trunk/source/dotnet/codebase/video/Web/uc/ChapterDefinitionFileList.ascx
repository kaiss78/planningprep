<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChapterDefinitionFileList.ascx.cs"
    Inherits="uc_ChapterDefinitionFileList" %>
<fieldset style="width:400px">
    <legend><strong>Exel file list</strong></legend>
    <asp:Repeater ID="rptFileList" runat="server" OnItemDataBound="rptFileList_ItemDataBound">
        <HeaderTemplate>
            <table cellpadding="3" cellspacing="0" width="100%">
                <colgroup>
                    <col style="width: 60%;" />
                    <col style="width: 20%;" />
                    <col style="width: 20%;" />
                </colgroup>
                <tr>
                    <td class="listName">
                        <asp:Label ID="lblFileName" Font-Bold="true" runat="server" Text="File Name"></asp:Label>
                    </td>
                    <td class="listName">
                        <asp:HyperLink ID="hplDelete" Font-Bold="true" runat="server" Text="Delete"></asp:HyperLink>
                    </td>
                     <td class="listName">
                        <asp:HyperLink ID="hplDownload" Font-Bold="true" runat="server" Text="Download"></asp:HyperLink>
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="OddRowListing">
                <td>
                    <asp:Label ID="lblFile" runat="server" Text=''></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="hplDownload" style="cursor:pointer" runat="server">Download</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="hplDelete" style="cursor:pointer" runat="server">Delete</asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="OddRowListing">
                <td>
                    <asp:Label ID="lblFile" runat="server" Text=''></asp:Label><asp:HyperLink ID="hlinkUser"
                        runat="server"></asp:HyperLink>
                </td>
                 <td>
                    <asp:HyperLink ID="hplDownload" style="cursor:pointer" runat="server">Download</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="hplDelete" style="cursor:pointer" runat="server">Delete</asp:HyperLink>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</fieldset>
