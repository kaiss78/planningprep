<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChapterDefinitionFileList.ascx.cs"
    Inherits="uc_ChapterDefinitionFileList" %>
<fieldset style="width:400px">
    <legend><strong>Exel file list</strong></legend>
    <asp:Repeater ID="rptFileList" runat="server" 
        OnItemDataBound="rptFileList_ItemDataBound" 
        onitemcommand="rptFileList_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="3" cellspacing="0" width="100%">
                <colgroup>
                    <col style="width: 40%;" />
                    <col style="width: 20%;" />
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
                     <td class="listName">
                        <asp:HyperLink ID="hplChapters" Font-Bold="true" runat="server" Text="See Video"></asp:HyperLink>
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="OddRowListing">
                <td>
                    <asp:Label ID="lblFile" runat="server" Text=''></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="hplDownload" CommandName="Download" style="cursor:pointer" runat="server">Download</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="hplDelete" OnClientClick="return confirm('Are you sure you want to delete?')" CommandName="Delete" style="cursor:pointer" runat="server">Delete</asp:LinkButton>
                </td>
                 <td>
                    <asp:HyperLink ID="hplChapters" style="cursor:pointer" runat="server">View</asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="OddRowListing">
                <td>
                    <asp:Label ID="lblFile" runat="server" Text=''></asp:Label>
                </td>
                 <td>
                    <asp:LinkButton ID="hplDownload" CommandName="Download" style="cursor:pointer" runat="server">Download</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="hplDelete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?')" style="cursor:pointer" runat="server">Delete</asp:LinkButton>
                </td>
                <td>
                    <asp:HyperLink ID="hplChapters" style="cursor:pointer" runat="server">View</asp:HyperLink>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</fieldset>
