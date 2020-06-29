using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Send_Mail_Mvc.Models;

namespace Send_Mail_Mvc.Controllers
{
    public class SendMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Email email)
        {
            string address = "yerliparla@gmail.com";
            string to = email.To;
            string subject = email.Subject;
            string body = email.Body;
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress(address);
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("yerliparla@gmail.com", "PY147py*");
            smtp.Send(mail);
            ViewBag.message = "The mail Has Been Send To" + email.To + " Successfully..!!!";
            return View();

        }
    }
}