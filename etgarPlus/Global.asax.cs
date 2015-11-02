using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Configuration;

namespace etgarPlus
{
 
    public class Global : HttpApplication
    {
      

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        internal static void sendEmail(string subject, string body, string emailTo)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            //string emailFrom = "brachafab@gmail.com";
            string emailFrom = System.Configuration.ConfigurationManager.AppSettings["Email"];
            //string emailpassword = "0503389483";
            string emailpassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, emailpassword);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);

                }
            }
        }
        internal static String uploadImage(string filePath) 
        {


            //CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary();
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("hmtca4hsp", "551419468127826", "6CRKqZzHmHxqCvpLaObNj2Hmsis");

            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            CloudinaryDotNet.Actions.ImageUploadParams uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams()
            {
                File = new CloudinaryDotNet.Actions.FileDescription(filePath),//@"C:\Users\David\Downloads\etgarPlusWebsite-master\etgarPlusWebsite\etgarPlus\images\1.png"),
                PublicId = "6"
            };

            CloudinaryDotNet.Actions.ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);


            string url = cloudinary.Api.UrlImgUp.BuildUrl("6" + filePath.Substring(filePath.LastIndexOf(".")));
            return url;
        }
    }
}