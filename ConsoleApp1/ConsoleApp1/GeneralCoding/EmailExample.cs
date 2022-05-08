using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EmailExample
    {
        static void GmailSet(string htmlString)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("sridhargiri1@gmail.com");
            message.To.Add(new MailAddress("sridhargiri1@gmail.com"));
            message.Subject = "Test";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = htmlString;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("sridhargiri1@gmail.com", "hellogmail@123");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
        static void OutlookSet(string htmlString)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("sridhar.swaminathan@puresoftware.com");
            message.To.Add(new MailAddress("sridhar.swaminathan@puresoftware.com"));
            message.Subject = "Test";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = htmlString;
            smtp.Port = 25;
            smtp.Host = "smtp.office365.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("sridhar.swaminathan", "Passpass04@");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
        public static void Email(string htmlString)
        {
            try
            {
                OutlookSet(htmlString);
            }
            catch
            {
                throw;
            }
        }
        public static void Main(string[] args)
        {
            Email("<b>htmlString 123</b>"); Pqr p = new Pqr();
        }
    }
    public abstract class Abc
    {
        public int a, b;
        public Abc()
        {

        }
        public Abc(int a1, int b1)
        {
            a = a1;
            b = b1;
        }

    }
    public class Pqr : Abc
    {
        public Pqr() : base()
        {

        }

    }
}
