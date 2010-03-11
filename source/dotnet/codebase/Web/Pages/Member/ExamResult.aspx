<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Member/MasterPageMember.master" CodeFile="ExamResult.aspx.cs" Inherits="Pages_Private_ExamResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        table td{
            vertical-align:top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
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
</asp:Content>
