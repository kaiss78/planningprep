<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">        
        ul{
            margin-left:10px;
            padding-left:10px;
        }
        /*li
        {
        	margin-left:0px;
            padding-left:0px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="homepagecontentbox">
        <div class="contentheading">What is Planning Prep?</div>
        Planning Prep is a membership site that provides members with study aides to help them prepare 
        for the American Institute of Certified Planner's* certification exam. <br /><br /> 

        Members have access to our growing database of practice questions, practice exams, 
        planning related links, and are able to participate in our discussion forums. <br /><br />

        Currently, we have 1025 practice questions and 7 practice exams aimed at refreshing, 
        broadening, and testing their planning knowledge. Each question contains an explanation for 
        each correct answer, so our members know why one answer is correct and another is not.  
        Links for further reading are also provided with our questions, to help our 
        members find additional information about the topic. We are constantly adding to our questions, 
        to make sure our materials are current and relevant. 
        The last question was added to our database on <%=_LastQuestionDate%><%--Thursday, October 15, 2009 at 10:40:06 PM--%>.
    </div>
    <div class="homepagecontentbox">
    <div class="contentheading">Features</div>
        <ul>
            <li>
                <%=_NumberOfQuestions.ToString()%> practice questions, 
		        taken by random, by category (i.e. history, theory and law), or 
		        searchable by keyword.&nbsp; Questions provide the answers to the 
		        questions, along with links providing additional research.<br/>
                &nbsp;
            </li>
            <li>
                7 Practice exams, 150-questions in length to 
		        help you pace and prepare for the AICP* exam.<br/>&nbsp;
		    </li>
            <li>
                Community forums to facilitate discussions other 
		        members about planning issues, potential exam topics, and anything else our members wish to 
		        talk about.<br/>&nbsp;
		    </li>
            <li>Summaries of articles in Planning Magazine.<br/>&nbsp;</li>
            <li>
                Detailed user statistics tell each of our 
		        members their strengths and weaknesses. They know how many questions 
		        they have taken, how many they have gotten correct, as a total and by 
		        area of focus.<br/>&nbsp;
		    </li>
            <li>Links to all types of websites and resources for further research.<br/>&nbsp;</li>
            <li>General test taking advice.<br/>&nbsp;</li>
            <li>
                Soon, members will be able to create their own 
		        questions to challenge their peers, and submit links to help their peers 
		        find useful information.
		    </li>
        </ul>
    </div>
    <div class="clearfloating"></div>
    <div class="OnePixelBorder"></div>
    
    <div class="homepagenewscontentbox">
        <img src="/Images/news1.jpg" align="left" alt="News 1" title="News 1" style="margin-right:20px;" />                        
        <div class="newsheading">First News</div>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non quam ut libero dictum pharetra.                     
    </div>
    <div class="homepagenewscontentbox">
        <img src="/Images/news2.jpg" align="left" alt="News 2" title="News 2" style="margin-right:20px;" />
        <div class="newsheading">Second News</div>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non quam ut libero dictum pharetra. 
    </div>
    <div class="homepagenewscontentbox">
        <img src="/Images/news3.jpg" align="left" alt="News 3" title="News 3" style="margin-right:20px;"  />
        <div class="newsheading">Third News</div>                        
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non quam ut libero dictum pharetra. 
    </div>
    <div class="clearfloating"></div>
</asp:Content>

