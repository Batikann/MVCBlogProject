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
using System.Web.Security;

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
        [ValidateAntiForgeryToken]
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
                //admin.DateOfBirth = DateTime.Now;
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


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin login)
        {
            string message = "";
            var v = blogDbContext.Admins.Where(a => a.AdminMail == login.AdminMail && a.IsEmailVerified==true).FirstOrDefault();
            if (v != null)
            {
                if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                {
                    FormsAuthentication.SetAuthCookie(login.AdminMail, false);
                    Session["AdminMail"] = login.AdminMail;
                    return RedirectToAction("AdminAuthorProfile", "AdminProfile");
                }

            }
            else
            {
                message = "Invalid credential provided";
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }



        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            blogDbContext.Configuration.ValidateOnSaveEnabled = false;

            var v = blogDbContext.Admins.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
            if (v != null)
            {
                v.IsEmailVerified = true;
                adminManager.Update(v);
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request";
            }
            ViewBag.Status = Status;
            return View();

        }



        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string id)
        {
            string message = "";
            bool status = false;
            var account = blogDbContext.Admins.Where(x => x.AdminMail == id).FirstOrDefault();
            if (account != null)
            {
                string resetcode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(account.AdminMail, resetcode, "ResetPassword");
                account.ResetPasswordCode = resetcode;
                blogDbContext.Configuration.ValidateOnSaveEnabled = false;
                adminManager.Update(account);
            }
            else
            {
                message = "Account Not Found";
            }



            return View();
        }


        public ActionResult ResetPassword(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }
            var user = blogDbContext.Admins.Where(x => x.ResetPasswordCode == id).FirstOrDefault();
            if (user != null)
            {
                user.ResetPasswordCode = id;
                return View(user);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(Admin admin)
        {
            var message = "";
            var user = blogDbContext.Admins.Where(a => a.ResetPasswordCode == admin.ResetPasswordCode).FirstOrDefault();
            if (user != null)
            {
                user.Password = Crypto.Hash(admin.Password);
                user.ResetPasswordCode = " ";
                blogDbContext.Configuration.ValidateOnSaveEnabled = false;
                adminManager.Update(user);
                message = "New password updated successfully";
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return View(admin);
        }







        [NonAction]
        public bool isEmailExist(string emailID)
        {
            var v = blogDbContext.Admins.Where(a => a.AdminMail == emailID).FirstOrDefault();
            return v != null;
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/RegisterAndLogin/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("emiruar1233@gmail.com");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "*******";
            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your Account is successfuly";
                body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
          " successfully created. Please click on the below link to verify your account" +
          " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/>br/>We got request for reset your account password. Please click on the below link to reset your password" +
            "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }




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