<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditFaqCategory.aspx.cs" 
    Inherits="Pages_Admin_EditFaqCategory" Title="Untitled Page" ValidateRequest="false" %>

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
    <div id="divHeading" class="contentheading" runat="server">Add New FAQ Category</div>
    
    <div id="divMessage" runat="server" visible="false"></div>
    
    <asp:Panel ID="pnlDetails" runat="server" DefaultButton="btnSave">
        <div class="floatleft" style="width:80px;">Category</div>
        <div class="floatleft">
            <asp:TextBox ID="txtCategory" runat="server" MaxLength="200"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" 
                ControlToValidate="txtCategory" Display="Dynamic"
                ErrorMessage="<br/>Please enter a FAQ Category Name."
                ValidationGroup="Save">
            </asp:RequiredFieldValidator>
        </div>
        <div class="clearfloating"></div>        
        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Save" />
        </div>        
    </asp:Panel>
</asp:Content>

