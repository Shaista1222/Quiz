using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Quiz.Controllers
{
    public class SubjectController : ApiController
    {
        QuizEntities db = new QuizEntities();
        Question question;
        QuestionOption questionOption;
        [HttpGet]
        public HttpResponseMessage GetSubjects()
        {
            try
            {
                /*List<Subject> subjects = new List<Subject>();*/
                return Request.CreateResponse(HttpStatusCode.OK, db.Subjects);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        /*
         [HttpGet]*/
        /*   public HttpResponseMessage GetSubjectQuiz(Subject subject)
           {
               try
               {
                   List<Question> quiz = new List<Question>();
                   for (int i = 0; i < question.id.Count; i++)
                   {
                       quiz.Add(new Question
                       {
                           description = question.description,
                           subject_id = question.subject_id,
                           question_id = questionOption.question_id,
                           option = questionOption.option
                       });
                   }

                   var quizList = quiz.ToList();
                   return Request.CreateResponse(HttpStatusCode.OK, quizList);
               }
               catch (Exception ex)
               {
                   return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
               }
           }*/
        [HttpGet]

        public HttpResponseMessage GetSubjectQuiz(int subjectId)
        {
            try
            {
                var result = db.Questions.Join(db.QuestionOptions, quizQuestion => quizQuestion.id, quizOption => quizOption.id,
                (quizQuestion, quizOption) => new { quizQuestion, quizOption }).Where(
                combined => combined.quizQuestion.id == questionOption.question_id && combined.quizQuestion.subject_id == subjectId).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error occurred: " + ex.Message);
            }
            /* int sub_id = db.Questions.Where(x => x.subject_id == subjectId).FirstOrDefault().id;*/
           
        }
    }
}