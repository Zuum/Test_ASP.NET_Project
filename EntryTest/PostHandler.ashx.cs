using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Routing;

namespace EntryTest
{
    /// <summary>
    /// Summary description for PostHandler
    /// </summary>
    public class PostHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
          
            var headers = context.Request.Headers;
            UploadWholeFile(context);
            context.Response.StatusCode = 200;
            
        }

        private void UploadWholeFile(HttpContext context)
        {
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                var file = context.Request.Files[i];

                if (!Directory.Exists(Environment.CurrentDirectory + "/SavedFiles"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "/SavedFiles");
                }

                var fullPath = Environment.CurrentDirectory + "/SavedFiles/" + Path.GetFileName(file.FileName);

                file.SaveAs(fullPath);

                string csvFilePath = ResponseMakers.XmlReportSerializer.DeserializeReport(fullPath);

                string topic = "Оплата задолженностей за период: " + DateTime.Now.Month;
                string body = "«Сгенерирован отчет оплаты задолженностей за период: " +
                    DateTime.Now.Month + " " + DateTime.Now.Year + "\n" + "\t\t\t\t\t\t\t" +
                    DateTime.Now.ToShortDateString();
                    
                var mailMessage = new MailMessage("YOURCOMPANY@gmail.com", "collection@bank.ru", topic, body);
                var attachment = new Attachment(csvFilePath);
                mailMessage.Attachments.Add(attachment);
            
                var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("YOURCOMPANY@gmail.com", "YOURPASSWORD"),
                    EnableSsl = true
                };

                smtpClient.Send(mailMessage);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class RouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new PostHandler();
        }
    }
}