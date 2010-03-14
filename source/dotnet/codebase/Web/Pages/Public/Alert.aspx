<%@ Page Language="C#" MasterPageFile="~/Pages/Member/MasterPageMember.master" AutoEventWireup="true" CodeFile="Alert.aspx.cs" Inherits="Pages_Public_Alert" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <b><font size="6" color="#FF0000">SECURITY ALERT</font></b>
    
    <div style="margin-top:15px;">
        Repeated multiple attempts have been made trying to access this site.

        Your IP Address (<%=_RemoteIP%>) has been logged multiple times trying to access this site.  
        Email notice has been issued to Planning Prep and your Internet Service Provider.&nbsp;&nbsp; 
        If you believe this is an error, please <a href="/Pages/Public/ContactUs.aspx">contact us</a>.
    </div>
</asp:Content>

