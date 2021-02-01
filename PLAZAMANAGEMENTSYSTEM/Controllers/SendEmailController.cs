using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Controllers
{
    public class SendEmailController : Controller
    {
        // GET: SendEmail
       

            [HttpPost]
        public JsonResult SendEmail (string email,string message)
        {
            try
            {
                string Myemail = System.Configuration.ConfigurationManager.AppSettings["Email"].ToString();

                string MyPassword = System.Configuration.ConfigurationManager.AppSettings["Password"].ToString();

                SmtpClient obj = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,

                    Timeout = 100000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Myemail, MyPassword)
                };

                MailMessage mailmessage = new MailMessage(Myemail, email, "Today's Report", message)
                {
                    IsBodyHtml = true,


                    BodyEncoding = Encoding.UTF8
                };

                obj.Send(mailmessage);

                return Json("EmailSent",JsonRequestBehavior.AllowGet);

            }


            catch(Exception e)
            {


                return null;
            }

        }



    }
}