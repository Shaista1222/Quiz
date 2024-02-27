using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Quiz.Controllers
{
    public class QuestionOptionController : ApiController
    {
        QuizEntities db= new QuizEntities();

        [HttpPost]      
        public HttpResponseMessage PostQuestionOption([FromBody] QuestionOption questionOption)
        {
            try
            {
                if (!string.IsNullOrEmpty(questionOption.option))
                {
                    QuestionOption newQuestionOption = new QuestionOption
                    {
                        question_id = questionOption.question_id,
                        option = questionOption.option,
                        is_correct = questionOption.is_correct
                    };

                    var result = db.QuestionOptions.Add(newQuestionOption);

                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Options cannot be null or empty.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error occurred: " + ex.Message);
            }
        }

    }
}
