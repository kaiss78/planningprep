<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamResult.aspx.cs" Inherits="Pages_Private_ExamResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    Total Questions
                </td>
                <td>
                    <asp:Label ID="lblTotalQuestions" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Total Correct answers
                </td>
                <td>
                    <asp:Label ID="lblTotalCorrectAnswers" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Percentage of correct answers
                </td>
                <td>
                    <asp:Label ID="lblPercentCorrectAnswers" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Avg time per question
                </td>
                <td>
                    <asp:Label ID="lblAvgTimePerQuestion" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
