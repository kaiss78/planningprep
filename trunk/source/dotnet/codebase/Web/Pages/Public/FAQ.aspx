<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="Pages_Public_FAQ" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="contentheading">Frequently Asked Questions</div>
    <div>
        Listed below are frequently asked questions about our site, our services, and other details. If you have a 
        question that is not answered below, feel free to contact us for more information,  The FAQs are sorted by 
        category. Click on a category to see questions relating to it.
    </div>
 

    <div>
        <ul>
            <asp:Repeater ID="rptCategoryList" runat="server" onitemdatabound="rptCategoryList_ItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="hplCategory" runat="server"></asp:HyperLink>                                      
                    </li>            
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div>
        <asp:Repeater ID="rptFaqList" runat="server" onitemdatabound="rptFaqList_ItemDataBound">
            <ItemTemplate>                
                <div id="divCategoryHeading" runat="server" visible="false" class="contentsubheading"></div>
                <div id="divQuestion" runat="server"></div>
                <div id="divAnswer" runat="server" class="faqanswer"></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

