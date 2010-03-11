<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Member/MasterPageMember.master" CodeFile="ExamDashboard.aspx.cs" Inherits="Pages_Private_ExamDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        table td{
            vertical-align:top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div>
        <asp:Repeater ID="rptExams" runat="server" OnItemDataBound="rptExams_ItemDataBound">
            <ItemTemplate>
            <div>
                <asp:Label ID="lblExamName" runat="server" Text="Label"></asp:Label>
            </div>
                <asp:Repeater ID="rptExamSessions" OnItemDataBound="rptExamSessions_ItemDataBound"
                    runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <div>
                                <asp:Label ID="LblExamSession" runat="server" Text=""></asp:Label>
                            </div>
                            <div>
                                <asp:HyperLink ID="hlinkFinishExam" Text="Click here to finish the exam" runat="server"></asp:HyperLink>
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                <div>
                    <asp:HyperLink ID="hlinkNewExamSession" Text="Click Here to Start A New Session of This Exam"
                        runat="server"></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
