<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/MasterPageMember.master" CodeFile="ExamResult.aspx.cs" Inherits="Pages_Private_ExamResult" %>

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
        
        .cogratsMessage
        {
        	font-weight:bold;
        	font-size:10pt;
        	margin-bottom:20px;
        }
        
        .detailsResult
        {
        	margin-top:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="largeText">
    Exam result for Exam #<asp:Label ID="lblExamNo" runat="server" Text=""></asp:Label>
    </div>
    <div class="cogratsMessage">
    Congratulations! You have completed Exam #<asp:Label ID="lblExamNo2" runat="server" Text=""></asp:Label>. Your exam results are below: 
    </div>
    <div>
        <div>
            <table style="width: 300px;">
            <tr>
                <td>
                    <strong>Total Questions</strong>
                </td>
                <td>
                    <asp:Label ID="lblTotalQuestions" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Total Correct answers</strong>
                </td>
                <td>
                    <asp:Label ID="lblTotalCorrectAnswers" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Percentage of correct answers</strong>
                </td>
                <td>
                    <asp:Label ID="lblPercentCorrectAnswers" runat="server" Text="0%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Avg time per question</strong>
                </td>
                <td>
                    <asp:Label ID="lblAvgTimePerQuestion" runat="server" Text="0"></asp:Label> Seconds
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Total Time</strong>
                </td>
                <td>
                    <asp:Label ID="lblTotalTime" runat="server" Text="0"></asp:Label> Seconds
                </td>
            </tr>
        </table>
        </div>
        <div class="detailsResult">
            <asp:GridView ID="gvResultDetails" runat="server" AutoGenerateColumns="False" 
                onrowdatabound="gvResultDetails_RowDataBound" BorderStyle="None" 
                BorderWidth="0px" CellPadding="5">
                <RowStyle CssClass="EvenRowListing" />
                <Columns>
                    <asp:BoundField DataField="SerialNo" HeaderText="Question No" />
                    <asp:HyperLinkField DataNavigateUrlFields="QuestionID" 
                        DataNavigateUrlFormatString="QuestionDetails.aspx?QuestionID={0}" 
                        DataTextField="Question" NavigateUrl="QuestionDetails.aspx" 
                        HeaderText="Question" />
                    <asp:BoundField DataField="CorrectAnswer" HeaderText="Correct Answer" />
                    <asp:BoundField DataField="YourAnswer" HeaderText="Your Answer" />
                    <asp:TemplateField HeaderText="Result">
                        <ItemTemplate>
                            <asp:Label ID="lblResult" runat="server" Text='<%# Bind("Result") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#FF9900" BorderColor="White" BorderStyle="None" 
                    BorderWidth="0px" ForeColor="White" />
                <AlternatingRowStyle CssClass="OddRowListing" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
