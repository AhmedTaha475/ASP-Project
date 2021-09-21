using ASP_Project_BLL.Model;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Helper
{
 public   class SendMail
    {

        public static string CreateMail(MailVM obj)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("SendingData.220@gmail.com"));
                email.To.Add(MailboxAddress.Parse(obj.Email));
                email.Subject = obj.Title;
                email.Body = new TextPart("Plain") { Text = obj.Message };

                using(var smtp = new SmtpClient())
                {

                    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate("SendingData.220@gmail.com", "ahmed@123456");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }


                return "Message sent successfully";




            }
            catch (Exception ex)
            {

                return "Failed To send";
            }

           
        }
    }
}
