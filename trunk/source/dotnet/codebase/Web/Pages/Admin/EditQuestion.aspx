<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditQuestion.aspx.cs" Inherits="Pages_Private_Admin_EditQuestion" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        textarea
        {
        	width:96%;
        }
        table td
        {
        	vertical-align:top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="contentheading"><asp:Literal ID="ltrHeading" runat="server"></asp:Literal></div>

    <div style="float:right;margin-bottom:10px;"><asp:HyperLink ID="hplQuestionList" runat="server">Back to Question List</asp:HyperLink></div>
    <div class="clearfloating"></div>
    <div>
        <table cellpadding="3" cellspacing="0" style="width:100%;"> 
            <colgroup>
                <col style="width:20%;" />
                <col style="width:30%;" />
                <col style="width:20%;" />
                <col style="width:30%;" />
            </colgroup>
            <tr> 
                <td>Question</td> 
                <td colspan="3"><asp:TextBox ID="txtQuestion" style="width:100%" runat="server" TextMode="MultiLine"></asp:TextBox></td> 
            </tr> 
            <tr> 
                <td>Answer A</td> 
                <td><asp:TextBox ID="txtAnswerA" runat="server" TextMode="MultiLine"></asp:TextBox></td> 
                <td>Answer C</td> 
                <td><asp:TextBox ID="txtAnswerC" runat="server" TextMode="MultiLine"></asp:TextBox></td> 
            </tr> 
            <tr> 
                <td>Answer B</td> 
                <td><asp:TextBox ID="txtAnswerB" runat="server" TextMode="MultiLine" ></asp:TextBox></td> 
                <td>Answer D</td> 
                <td><asp:TextBox ID="txtAnswerD" runat="server" TextMode="MultiLine"></asp:TextBox></td> 
            </tr> 
            <tr> 
                <td>Correct Answer</td> 
                <td>
                    <asp:DropDownList ID="ddlCorrectAnswer" runat="server" CssClass="DropDownListCommon" style="width:auto;">
                        <asp:ListItem Value="A" Text="A"></asp:ListItem>
                        <asp:ListItem Value="B" Text="B"></asp:ListItem>
                        <asp:ListItem Value="C" Text="C"></asp:ListItem>
                        <asp:ListItem Value="D" Text="D"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="2">&nbsp;</td> 
            </tr> 
            <tr> 
                <td>Explanation</td> 
                <td colspan="3"><asp:TextBox ID="txtExplanation" style="width:100%" runat="server" TextMode="MultiLine"></asp:TextBox></td> 
            </tr>             
            <%--
            <tr> 
                <td>Link 1</td> 
                <td><asp:TextBox ID="txtLink1" runat="server" CssClass="TextBoxCommon"></asp:TextBox></td> 
                <td>Link 1 Description</td> 
                <td><asp:TextBox CssClass="TextBoxCommon" ID="txtLink1Description" runat="server"></asp:TextBox></td> 
            </tr>             
            <tr> 
                <td>Link 2</td> 
                <td><asp:TextBox ID="txtLink2" runat="server" CssClass="TextBoxCommon"></asp:TextBox></td> 
                <td>Link 2 Description</td> 
                <td><asp:TextBox ID="txtLink2Description" runat="server" CssClass="TextBoxCommon"></asp:TextBox></td> 
            </tr>             
            --%>
            <tr> 
                <td>History, Theory and Law</td> 
                <td><asp:CheckBox ID="chkIsHistoryTheoryLaw" runat="server"></asp:CheckBox></td> 
                <td>Emerging Trends and Issues</td> 
                <td><asp:CheckBox ID="chkIsTrendsIssues" runat="server"></asp:CheckBox></td> 
            </tr> 
            <tr> 
                <td>Plan Making (methods, strategies &amp; techniques)</td> 
                <td><asp:CheckBox ID="chkIsPlanMaking" runat="server"></asp:CheckBox></td> 
                <td>Functional Topics</td> 
                <td><asp:CheckBox ID="chkIsFunctionalTopics" runat="server"></asp:CheckBox></td> 
            </tr>
            <tr> 
                <td>Plan Implementation</td> 
                <td><asp:CheckBox ID="chkIsPlanImplementation" runat="server"></asp:CheckBox></td> 
                <td>Codes of Ethics, Public Interest</td> 
                <td><asp:CheckBox ID="chkIsEthics" runat="server"></asp:CheckBox></td> 
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td style="text-align:right">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="ButtonCommon" onclick="btnSave_Click" />
                </td>
            </tr> 
        </table>        
    </div>
</asp:Content>

