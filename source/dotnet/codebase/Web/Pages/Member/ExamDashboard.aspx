<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="ExamDashboard.aspx.cs" Inherits="Pages_Private_ExamDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script language="javascript">
    function ExpandCollapse(id) {
        var divName = "Exam" + id;
        var labelName = "Label" + id;
        var imageName = "Img" + id;
        
        var ExpandCollapse = $("span[examsessionid=" + labelName + "]").text();
        if (ExpandCollapse == "+") {
            $("div[examsessionid=" + divName + "]").fadeIn();
            $("span[examsessionid=" + labelName + "]").text("-");
            $("img[examsessionid=" + imageName + "]").attr("src", "../../images/minus.gif");
        }
        else {
            $("div[examsessionid=" + divName + "]").fadeOut();
            $("span[examsessionid=" + labelName + "]").text("+");
            $("img[examsessionid=" + imageName + "]").attr("src", "../../images/plus.gif");
        }
        
    }
</script>
    <style type="text/css">
        table td
        {
            vertical-align: top;
        }
        .title
        {
        	font-weight:bold;
        	color:Green;
        	font-size:medium;
        }
        .ExamTitle
        {
        	font-weight:bold;
        	font-size:11px;
        	margin-bottom:10px;
        	background-color:#dddddd;
        	padding:5px 0px 5px 5px;
        	
        }
        .NewExam
        {
        	margin-top:20px;
        	margin-bottom:20px;
        	font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <div>
        <p class="contentheading">
            Exams
        </p>
        <p>
            Listed below are all the exams that will are available on Planning Prep. If an exam is not yet available, the launch date of that exam is displayed below. If you have already taken an exam, you can see your results below. Please feel report any bugs in our exam system.
        </p>
    </div>
    <div>
        <asp:Repeater ID="rptExams" runat="server" OnItemDataBound="rptExams_ItemDataBound">
            <ItemTemplate>
                <asp:Panel ID="pnlExam" runat="server" CssClass="ExamTitle">
                    <asp:Image ID="imgExpandCollapse" ImageUrl="~/Images/plus.gif" runat="server" /><asp:Label ID="lblExpandCollapse" style="display:none" runat="server" Text="+"></asp:Label><asp:Label ID="lblExamName" CssClass="ExamTitle" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlExamSession" runat="server">
               
                <asp:Repeater ID="rptExamSessions" OnItemDataBound="rptExamSessions_ItemDataBound"
                    runat="server">
                    <HeaderTemplate>
                        
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="OddRowListing">
                            <div>
                                <asp:Label ID="LblExamSession" runat="server" Text=""></asp:Label>
                            </div>
                            <div>
                                <asp:HyperLink ID="hlinkFinishExam" Text="Click here to finish the exam" runat="server"></asp:HyperLink>
                            </div>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                    <div class="EvenRowListing">
                            <div>
                                <asp:Label ID="LblExamSession" runat="server" Text=""></asp:Label>
                            </div>
                            <div>
                                <asp:HyperLink ID="hlinkFinishExam" Text="Click here to finish the exam" runat="server"></asp:HyperLink>
                            </div>
                        </div>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                    
                    </FooterTemplate>
                </asp:Repeater>
                <div class="NewExam">
                    <asp:HyperLink ID="hlinkNewExamSession" Text="Click Here to Start A New Session of This Exam"
                        runat="server"></asp:HyperLink>
                </div>
                 </asp:Panel>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
