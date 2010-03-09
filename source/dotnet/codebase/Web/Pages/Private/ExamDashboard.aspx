<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamDashboard.aspx.cs" Inherits="Pages_Private_ExamDashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
