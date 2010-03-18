<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="EditFAQ.aspx.cs" Inherits="Pages_Admin_EditFAQ" Title="Untitled Page" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        table td
        {
        	padding-left:0px;
        	vertical-align:top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div id="divHeading" runat="server" class="contentheading">Add New Question in the FAQ Database</div>
    
    <div id="divMessage" runat="server" visible="false"></div>
    
    <asp:Panel ID="pnlDetails" runat="server" DefaultButton="btnSave">        
        <table cellpadding="3" cellspacing="0" style="width:100%;">
            <colgroup>
                <col style="width:10%;" />
                <col style="width:90%;" />
            </colgroup>
            <tr>
                <td>Question</td>
                <td>
                    <asp:TextBox ID="txtQuestion" TextMode="MultiLine" runat="server" MaxLength="2000" style="width:95%;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" 
                        ControlToValidate="txtQuestion" Display="Dynamic"
                        ErrorMessage="<br/>Please enter a Question."
                        ValidationGroup="Save">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Answer</td>
                <td>
                    <asp:TextBox ID="txtAnswer" TextMode="MultiLine" runat="server" MaxLength="2000" style="width:95%;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" 
                        ControlToValidate="txtAnswer" Display="Dynamic"
                        ErrorMessage="<br/>Please enter an Answer."
                        ValidationGroup="Save">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Category</td>
                <td>
                    <asp:DropDownList ID="ddlFaqCategory" CssClass="DropDownListCommon" style="width:auto;" runat="server">
                    </asp:DropDownList>
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

