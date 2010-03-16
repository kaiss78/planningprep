﻿using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;
using App.Models.Comments;
using App.Models.Questions;
using App.Domain.Questions;

/// <summary>
/// Summary description for AjaxService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
[ScriptService]    
public class AjaxService : System.Web.Services.WebService
{

    public AjaxService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod(EnableSession = true)]
    public String HelloWorld()
    {
        return "Hello World";
    }
    
    [WebMethod(EnableSession = true)]
    public long SaveComment(App.Models.Comments.Comment comment)
    {
        App.Domain.Comments.CommentManager manager = new App.Domain.Comments.CommentManager();        
        manager.SaveOrUpdate(comment);
        return comment.Id;
    }
    [WebMethod(EnableSession = true)]
    public int CommentThumbsUp(int commentID)
    {
        App.Domain.Comments.CommentManager manager = new App.Domain.Comments.CommentManager();
        Comment comment =  manager.Get(commentID);
        if (comment != null)
        {
            comment.Rank = comment.Rank + 1;
            manager.SaveOrUpdate(comment);
            return comment.Rank - comment.NegativeRank;
        }
        return 0;
    }
    /// <summary>
    /// Saves Thumbs Down Data
    /// </summary>
    /// <param name="commentID"></param>
    [WebMethod(EnableSession = true)]
    public int CommentThumbsDown(int commentID)
    {
        App.Domain.Comments.CommentManager manager = new App.Domain.Comments.CommentManager();
        Comment comment = manager.Get(commentID);
        if (comment != null)
        {
            comment.NegativeRank = comment.NegativeRank + 1;
            manager.SaveOrUpdate(comment);
            return comment.Rank - comment.NegativeRank;
        }        
        return 0;
    }
    [WebMethod(EnableSession = true)]
    public void SaveQuestionRating(long questionID, int selectedRating)
    {
        //int selcetedRating = int.Parse(rdoRating.SelectedValue);
        QuestionsManager questionManager = new QuestionsManager();
        Questions question = questionManager.Get(questionID);
        if (question != null)
        {
            question.RateTotal += selectedRating;
            question.RateCount++;
            question.Rating = (float)question.RateTotal / (float)question.RateCount;
            questionManager.SaveOrUpdate(question);
        }       
    }
}

