<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaginatedUsers.ascx.cs"
    Inherits="UserControls_PaginatedUsers" %>
    
<%@ Register Src="/UserControls/Pager.ascx" TagName="Pager" TagPrefix="Pager" %>
<%@ Register Src="/UserControls/ModalMessage.ascx" TagName="ModalMessage" TagPrefix="UC" %> 

<script language="javascript" type="text/javascript">
    function CheckAllUsers()
    {
        $('.selectuser').attr('checked', 'checked');
    }
    function UnCheckAllUsers()
    {
        $('.selectuser').removeAttr('checked');
    }
    function GetCommaSeparatedIDsOfSelectedUsers()
    {
        var userIDs = '';        
        var counter = 0;
        $('.selectuser').each(function(){                        
            if($(this).is(':checked'))
            {
                if(counter == 0)                    
                    userIDs = $(this).val();
                else
                    userIDs += ',' + $(this).val(); 
                counter++;               
            }
        });
        return userIDs;
    }
    function SendEmailToSelectedUsers()
    {
        var userIDs = GetCommaSeparatedIDsOfSelectedUsers();
        if(userIDs.length == 0)
            CreateConfirmationPopup('confirm', 'Information', 'Please select users from the <b>User List</b> to send them email.');
        else
        {
            var Url = '<%=AppConstants.Pages.SEND_EMAIL %>?<%=AppConstants.QueryString.ID %>=' + userIDs ;            
            Url = Url + '&rnd=' + GetRandomNumber();
            window.location = Url;
        }
    }    
    function SendEmailToAllUsers()
    {
        var Url = '<%=AppConstants.Pages.SEND_EMAIL %>?<%=AppConstants.QueryString.ID %>=All';
        Url = Url + '&rnd=' + GetRandomNumber();
        window.location = Url;
    }
</script>

<div class="contentheading">User List</div>
<div>
    <asp:Label ID="lblNoUserFoundMessage" Visible="false" runat="server" Text="No User found."></asp:Label>
</div>
<asp:Repeater ID="rptUserList" runat="server" OnItemDataBound="rptUserList_ItemDataBound">
    <HeaderTemplate>
        <table cellpadding="3" cellspacing="0" width="100%">
            <colgroup>
                <col style="width: 12%;" />
                <col style="width: 63%;" />
                <col style="width: 15%;" />
                <col style="width: 10%;" />
            </colgroup>
            <tr>                
                <td>
                    Select: <a href="javascript:void(0);" onclick="CheckAllUsers();">All</a> <a href="javascript:void(0);" onclick="UnCheckAllUsers();">None</a> 
                </td>
                <td class="listName">
                    <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="listName">
                    <asp:Label ID="lblLastModified" runat="server" Text="Last Modified"></asp:Label>
                </td>
                <td class="listName">
                    <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="OddRowListing">
            <td><input class="selectuser" type="checkbox" id="chkSelectUser" runat="server" /></td>
            <td>
                <asp:Label ID="lblUser" runat="server" Text=''></asp:Label><asp:HyperLink ID="hlinkUser"
                    runat="server"></asp:HyperLink>
            </td>
            <td>
                <asp:Label ID="lbLastModifiedDate" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink>
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="EvenRowListing">
            <td><input class="selectuser" type="checkbox" id="chkSelectUser" runat="server" /></td>
            <td>
                <asp:Label ID="lblUser" runat="server" Text=''></asp:Label><asp:HyperLink ID="hlinkUser"
                    runat="server"></asp:HyperLink>
            </td>
            <td>
                <asp:Label ID="lbLastModifiedDate" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="hplEdit" runat="server">Edit</asp:HyperLink>
            </td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

<div>
    <input type="button" class="ButtonCommon" value="Send Email to Selected User(s)" onclick="SendEmailToSelectedUsers();" />
    <input type="button" class="ButtonCommon" value="Send Email to All Users" onclick="SendEmailToAllUsers();" />
</div>
<div style="margin-top: 20px;">
    <Pager:Pager ID="ucPager" runat="server" OnPageIndexChanged="ucPager_PageIndexChanged" />
</div>

<UC:ModalMessage id="ucModalMessage" runat="server"></UC:ModalMessage>