using BusinessLayer.Concrete;
using BusinessLayer.Utilities.Hashing;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.AdminPanel
{
    public class RegisterAndLoginController : Controller
    {
        BlogDBContext blogDbContext = new BlogDBContext();
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        AdminValidator adminValidator = new AdminValidator();
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Admin admin)
        {
            //ValidationResult result = adminValidator.Validate(admin);
            bool Status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                var isExist = isEmailExist(admin.AdminMail);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email Already Exist");
                    return View(admin);
                }
                
                admin.ActivationCode = Guid.NewGuid();
                admin.Password = Crypto.Hash(admin.Password);
                admin.IsEmailVerified = false;
                admin.DateOfBirth = DateTime.Now;
                adminManager.Add(admin);
                SendVerificationLinkEmail(admin.AdminMail, admin.ActivationCode.ToString());
                message = "Registration successfully done. Account activation link " +
                    " has been sent to your email id:" + admin.AdminMail;
                Status = true;
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(admin);
        }

        [NonAction]
        public bool isEmailExist(string emailID)
        {
            var v = blogDbContext.Admins.Where(a => a.AdminMail == emailID).FirstOrDefault();
            return v != null;
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            var verifyUrl = "User/VerifyAccount" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("emiruar1233@gmail.com");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "*********";
            string subject = "Your Account is successfuly";
            string body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
       " successfully created. Please click on the below link to verify your account" +
       " <br/><br/><a href='" + link + "'>" + link + "</a> ";


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

    }
}