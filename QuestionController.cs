using Quiz.Models;
using Quiz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Results;

namespace Quiz.Controllers
{
    public class QuestionController : ApiController
    {
        QuizEntities db = new QuizEntities();
        QuestionService questionService = new QuestionService();
     
        [HttpPost]
        public HttpResponseMessage PostQuestion([FromBody] Question question)
        {
            
            try
            {
                if (!string.IsNullOrEmpty(question.description))
                {
                    Question newQuestion = new Question
                    {
                        description = question.description,
                        subject_id = question.subject_id                       
                    };
                   var result= db.Questions.Add(newQuestion);

                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Description cannot be null or empty.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error occurred: " + ex.Message);
            }
        }
               
    }
}
