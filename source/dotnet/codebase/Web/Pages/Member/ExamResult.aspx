<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Member/MasterPageMember.master" CodeFile="ExamResult.aspx.cs" Inherits="Pages_Private_ExamResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        table td{
            vertical-align:top;
        }
        .largeText
        {
        	font-weight:bold;
        	color:Green;
        	font-size:medium;
        	margin-bottom:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="largeText">
    Exam result
    </div>
    <div>
        <table style="width: 60%;">
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
                    <asp:Label ID="lblAvgTimePerQuestion" runat="server" Text=""></asp:Label> Seconds
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
