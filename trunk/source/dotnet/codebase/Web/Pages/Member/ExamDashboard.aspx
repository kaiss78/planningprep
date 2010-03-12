<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Member/MasterPageMember.master"
    CodeFile="ExamDashboard.aspx.cs" Inherits="Pages_Private_ExamDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        	font-size:11pt;
        	margin-bottom:10px;
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
        <p class="title">
            Exams
        </p>
        <p>
            Listed below are all the exams that will are available on Planning Prep. If an exam is not yet available, the launch date of that exam is displayed below. If you have already taken an exam, you can see your results below. Please feel report any bugs in our exam system.
        </p>
    </div>
    <div>
        <asp:Repeater ID="rptExams" runat="server" OnItemDataBound="rptExams_ItemDataBound">
            <ItemTemplate>
                <div class="ExamTitle">
                    <asp:Label ID="lblExamName"  runat="server" Text=""></asp:Label>
                </div>
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
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
