using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using AK.Areas.Identity.Data;
using AK.Models;

namespace AK.Controllers
{
    public class MailController : Controller
    {
        private readonly ILogger<MailController> _logger;

        public MailController(ILogger<MailController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Mail()
        {
            //MailDTo model = new MailDTo();
            //// Set the email details
            //model.From = "akashks6341@gmail.com";
            //model.To = "akashks6341@gmail.com";
            //model.Subject = "Test Email";
            //model.Message= "This is a test email sent from MVC.";

            //// Send the email
            //Mail(model);

            return View();
           
        }

        [HttpPost]
        public ViewResult Mail(MailDTo Mail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(Mail.To);
                mail.From = new MailAddress(Mail.From);
                mail.Subject = Mail.Subject;
                string Body = Mail.Message;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("akashks6341@gmail.com", "zlhxfpivlrpqnsxn"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", Mail);

                //return RedirectToAction("Mail");
            }
            else
            {
                return View();
            }
        }

    }
}
