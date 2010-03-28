<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ViewChapters.aspx.cs" Inherits="ViewChapters" %>

<%@ Register src="~/uc/Chapters.ascx" tagname="Chapters" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID="BodyContents" ID="Content1" runat="server">

    <script language="javascript">
    $(function(){
        // Document is ready
        $(".expandCollapseDiv").click(function () { 
            var wrapperId = $(this).attr("wrapperId");
            
            if($(this).text() == "+")
            {
                $("div[childrenId=" + wrapperId +"]").show(100);
                $(this).text("-");
            }
            else
            {
                $("div[childrenId=" + wrapperId +"]").hide(100);               
                $(this).text("+");
            }
            
        });

    });
    
  
</script>

    <div>
    
    </div>
    <uc1:Chapters ID="chapters" runat="server" />

</asp:Content>