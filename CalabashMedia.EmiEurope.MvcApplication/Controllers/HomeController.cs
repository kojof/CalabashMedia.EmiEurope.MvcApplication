using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult HealthCare()
        {
            return View();
        }

        public ActionResult Clients()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendRegisterEmail(RegisterEmail registerEmail)
        {
            if (ModelState.IsValid)
           {
                string emailSubject = WebConfigurationManager.AppSettings["RegisterEmailToSendSubject"];
                string emailTo = WebConfigurationManager.AppSettings["RegisterEmailToSendTo"];
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(registerEmail.EmailAddress);
                mailMessage.Subject = emailSubject;
                mailMessage.To.Add(emailTo);
                mailMessage.Body = EmailMessage(registerEmail);
                mailMessage.IsBodyHtml = true;

                if(registerEmail.Attachment != null)
                {
                   mailMessage.Attachments.Add(new Attachment(registerEmail.Attachment.InputStream, registerEmail.Attachment.FileName));
                }
                
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMessage);

                return View("RegisterEmailThankYou", registerEmail);
             }
            return View("Register");
        }

        [HttpPost]
        public ActionResult SendQuickRegisterEmail(QuickRegisterEmail registerEmail)
        {
            if (ModelState.IsValid)
            {
                string emailSubject = WebConfigurationManager.AppSettings["RegisterEmailToSendSubject"];
                string emailTo = WebConfigurationManager.AppSettings["RegisterEmailToSendTo"];
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(registerEmail.EmailAddress);
                mailMessage.Subject = emailSubject;
                mailMessage.To.Add(emailTo);
                mailMessage.Body = EmailMessage(registerEmail);
                mailMessage.IsBodyHtml = true;

                if (registerEmail.Attachment != null)
                {
                    mailMessage.Attachments.Add(new Attachment(registerEmail.Attachment.InputStream, registerEmail.Attachment.FileName));
                }

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMessage);

                return View("QuickRegisterEmailThankYou", registerEmail);
            }
            return View("Index");
        }


        private string EmailMessage(RegisterEmail registerEmail)
        {
            StringBuilder sbMailMessage = new StringBuilder();
            sbMailMessage.AppendLine("<h2>EMI Europe Registration Form</h2>");
            sbMailMessage.AppendLine("Dear Sir|Madam,<br><br> " + registerEmail.Title + " " + registerEmail.FirstName + " " + registerEmail.LastName + " has an enquiry.<br><br>");
            sbMailMessage.AppendLine("<b>Company</b> :&nbsp; &nbsp; "+ registerEmail.Company +".<br>");
            sbMailMessage.AppendLine("<b>Address</b> :&nbsp; &nbsp;"+ registerEmail.Address1 +".<br>");            
            sbMailMessage.AppendLine("<b>Address</b> :&nbsp; &nbsp;"+ registerEmail.Address2 +".<br>");
            sbMailMessage.AppendLine("<b>City</b> :&nbsp; &nbsp;"+ registerEmail.TownCity +".<br>");
            sbMailMessage.AppendLine("<b>County</b> :&nbsp; &nbsp;" + registerEmail.County +".<br>");
            sbMailMessage.AppendLine("<b>State</b> :&nbsp; &nbsp;"+ registerEmail.State +".<br>");
		    sbMailMessage.AppendLine("<b>Post Code</b> :&nbsp; &nbsp;"+ registerEmail.PostCode +".<br>");
            sbMailMessage.AppendLine("<b>Country</b> :&nbsp; &nbsp;" + registerEmail.Country +".<br>");
		    sbMailMessage.AppendLine("<b>Telephone Number</b> :&nbsp; &nbsp;"+ registerEmail.Telephone +".<br>");
		    sbMailMessage.AppendLine("<b>Mobile Number</b> :&nbsp; &nbsp;"+ registerEmail.Mobile +".<br>");
            sbMailMessage.AppendLine("<b>Email Address</b> : " + registerEmail.EmailAddress +".<br>");
            sbMailMessage.AppendLine("<b>Desired Location</b> : " + registerEmail.DesiredLocation +".<br>");
            sbMailMessage.AppendLine("<b>Desired Position</b> : " + registerEmail.DesiredPosition + ".<br>");
            sbMailMessage.AppendLine("<b>Profession</b> : " + registerEmail.Profession + ".<br>");
            sbMailMessage.AppendLine("<b>Enquiry</b>: &nbsp;"+ registerEmail.Comments +".<br><br>"+ registerEmail.FirstName +" "+ registerEmail.LastName +"</p>");
            return sbMailMessage.ToString();
        }

        private string EmailMessage(QuickRegisterEmail registerEmail)
        {
            StringBuilder sbMailMessage = new StringBuilder();
            sbMailMessage.AppendLine("<h2>EMI Europe Registration Form</h2>");
            sbMailMessage.AppendLine("Dear Sir|Madam,<br><br> " + registerEmail.Title + " " + registerEmail.FirstName + " " + registerEmail.LastName + " has an enquiry.<br><br>");
           
            sbMailMessage.AppendLine("<b>Telephone Number</b> :&nbsp; &nbsp;" + registerEmail.Telephone + ".<br>");
            sbMailMessage.AppendLine("<b>Email Address</b> : " + registerEmail.EmailAddress + ".<br>");
            sbMailMessage.AppendLine("<b>Profession</b> : " + registerEmail.Profession + ".<br>");
            sbMailMessage.AppendLine("<br>" + registerEmail.FirstName + " " + registerEmail.LastName + "</p>");
            return sbMailMessage.ToString();
        }
        
    }
}
