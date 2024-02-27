using Quiz.Models;
using Quiz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Quiz.Controllers
{
    public class RegistrationController : ApiController
    {
        Registration registration;
        RegisterUser registerUser= new RegisterUser();
        // GET: Registration
        /*Register a new user for quiz*/
        [HttpPost]
        public HttpResponseMessage PostUser([FromBody] Registration registration)
        {
            if (registerUser.AddUser(registration))
            {
                return Request.CreateResponse(HttpStatusCode.OK, registration);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, registerUser.message);
        }
        /*Login a user*/
        [HttpGet]
        public HttpResponseMessage Login(string email, string password)
        {
            QuizEntities db = new QuizEntities();
            try
            {
                registration = db.Registrations.Where(reg => reg.email.Equals(email) && reg.password.Equals(password)).FirstOrDefault();
                if (registration != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Login successful");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
