<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager.ascx.cs" Inherits="UserControl_Pager" %>

<div id="divPager" runat="server" visible="false">    
    <div class="PagerButton" style="margin-left:0px; width:70px;">
        <asp:LinkButton ID="lnkPrevious" runat="server" Text="Previous" OnClick="lnkNextPrevious_Click"></asp:LinkButton>                        
        <asp:Label ID="lblPrevious" Visible="false" runat="server" Text="Previous" style="font-size: x-small;"></asp:Label>
    </div>

    <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand" OnItemDataBound="rptPages_ItemDataBound">                
        <ItemTemplate>
            <div id="divPagerContainer" runat="server" class="PagerButton">
                <asp:LinkButton ID="lnkPage" runat="server" Text='<%# Eval("PageNo") %>' CommandArgument='<%# Eval("PageNo") %>'></asp:LinkButton>                                
                <asp:Label ID="lblListingCurrentPage" CssClass="CurrentPage" runat="server" Text="" Visible="false"></asp:Label>
            </div>       
        </ItemTemplate>
    </asp:Repeater>

    <div class="PagerButton">
        <asp:LinkButton ID="lnkNext" runat="server" Text="Next" OnClick="lnkNextPrevious_Click"></asp:LinkButton>
        <asp:Label ID="lblNext" Visible="false" runat="server" Text="Next" style="font-size: x-small;"></asp:Label>
    </div>
    <div id="divPageCount" runat="server" class="MessageCommon" style="float:right; text-align:right; padding-top:5px;"></div>
    <asp:Label ID="lblCurrentPage" runat="server" Visible="false"></asp:Label>
</div>
<div style="clear:both;"></div>