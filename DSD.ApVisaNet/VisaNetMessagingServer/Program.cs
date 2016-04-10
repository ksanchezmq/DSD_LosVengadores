using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Mail;
using System.Text;
using WCFCienteServices.Entidad;

namespace VisaNetMessagingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando proceso de mensajeria");

            string rutaCola = @".\private$\DSD_LosVengadores";

            if (!MessageQueue.Exists(rutaCola))
            {
                MessageQueue.Create(rutaCola);
            }

            var cola = new MessageQueue(rutaCola);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Notificacion) });

            var lista = new List<Notificacion>();
            var messages = cola.GetAllMessages();
            var totalMessages = messages.Count();

            for (int i = 0; i < totalMessages; i++)
            {
                var mensaje = cola.Receive();
                var notificacion = (Notificacion)mensaje.Body;

                EnviarNotificacion(notificacion);
            }

            Console.WriteLine("Finalizando proceso de mensajeria");
            Console.ReadLine();
        }


        static void EnviarNotificacion(Notificacion notificacion)
        {
            var host = ConfigurationManager.AppSettings["EmailServer"];

            var fromAddress = ConfigurationManager.AppSettings["UserNameSMTP"];
            var toAddress = notificacion.ToAddress;
            var fromPassword = ConfigurationManager.AppSettings["PasswordSMTP"];
            var subject = notificacion.Subject;
            var body = notificacion.Body;

            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromAddress, "Graziella Villafuerte", Encoding.UTF8);
                    mail.To.Add(toAddress);
                    mail.Priority = MailPriority.Normal;
                    mail.Subject = subject;
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.Body = body;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = false;

                    using (var smtp = new SmtpClient())
                    {
                        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                        smtp.Host = host;
                        smtp.Port = 587;
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                };
                Console.WriteLine("Notificacion exitosa");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("Notificacion fallida");
                //throw ex;
            }
        }
    }
}
