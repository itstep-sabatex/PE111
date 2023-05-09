using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace SMTPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .AddUserSecrets<Program>()
                            .Build();
            var pass = config.GetSection("Password").Value;
            var conf = new Config();
            config.Bind(conf);

            //MailMessage message = new MailMessage();
            //SmtpClient smtpClient = new SmtpClient();
            //message.From = new MailAddress("test@mail.com","Іван Іванович",System.Text.Encoding.UTF8);
            //message.To.Add(new MailAddress("test@mail.com"));
            //message.Subject = "Test";
            //message.Body = "Test Mail";


            //smtpClient.Host="smtp.gmail.com";
            //smtpClient.EnableSsl = true;
            //NetworkCredential networkCredential = new NetworkCredential();
            //networkCredential.Password =conf.Password;
            //networkCredential.UserName = conf.UserName;

            //smtpClient.UseDefaultCredentials = true;
            //smtpClient.Credentials = networkCredential;
            //smtpClient.Port = conf.Port;   
            //smtpClient.Send(message);

            var message = new MimeMessage();
            SmtpClient smtpClient = new SmtpClient();
            //message.From.Add( MailBoxAddress("test@mail.com", "Іван Іванович", System.Text.Encoding.UTF8);
            //message.To.Add(new MailAddress("test@mail.com"));
            //message.Subject = "Test";
            //message.Body = "Test Mail";


            //smtpClient.Host = "smtp.gmail.com";
            //smtpClient.EnableSsl = true;
            //NetworkCredential networkCredential = new NetworkCredential();
            //networkCredential.Password = conf.Password;
            //networkCredential.UserName = conf.UserName;

            //smtpClient.UseDefaultCredentials = true;
            //smtpClient.Credentials = networkCredential;
            //smtpClient.Port = conf.Port;
            //smtpClient.Send(message);


        }
    }
}