using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Quiz.Services
{
    public class RegisterUser
    {
        QuizEntities db = new QuizEntities();
        public string message = string.Empty;
        public bool AddUser(Registration registration)
        {
            if (ValidateUserData(registration))
            {
                try
                {
                    db.Registrations.Add(registration);
                    int i = db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            return false;
        }

        public bool ValidateUserData(Registration registration)
        {
            if (registration.name == string.Empty)
            {
                message = "Please Enter Name";
            }
            else if (!Regex.IsMatch(registration.email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                if (string.IsNullOrEmpty(registration.email))
                    message = "Please Enter Email";
                else
                    message = "Email is not valid";
            }
            else if (!Regex.IsMatch(registration.password, @".{3,6}$"))
            {
                if (string.IsNullOrEmpty(registration.password))
                    message = "Please Enter Password";
                else
                    message = "Password should be of 3 to 6 characters";
            }
            if (message == string.Empty)
                return true;

            return false;
        }
    }
}