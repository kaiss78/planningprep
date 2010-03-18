<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditFaqCategory.aspx.cs" Inherits="Pages_Admin_EditFaqCategory" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div id="divHeading" class="contentheading" runat="server">Add New FAQ Category</div>
    
    <div id="divMessage" runat="server" visible="false"></div>
    
    <asp:Panel ID="pnlDetails" runat="server" DefaultButton="btnSave">
        <table cellpadding="3" cellspacing="0" style="width:100%;">
            <colgroup>
                <col style="width:10%;" />
                <col style="width:90%;" />
            </colgroup>
            <tr>
                <td>Category</td>
                <td>
                    <asp:TextBox ID="txtCategory" runat="server" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" 
                        ControlToValidate="txtCategory" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a FAQ Category Name."
                        ValidationGroup="Save">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>            
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Save" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

