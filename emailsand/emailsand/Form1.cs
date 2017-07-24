using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace emailsand
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              {


            try
            {
                // first login Gmail account
                //Go to "My Account" settings.
                //Click "Sign-in & Security" category.
                //Scroll down to "Connected apps & sites" section.
                //turn off the "Allow less secure apps" option.

               

                string mailadd = "Demo@gmail.com";
                string pwd = "123456";

                string recever = "test@gmail.com";

                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress(mailadd);
                // Recipient e-mail address.
                Msg.To.Add(recever);
                Msg.Subject = "test";
                Msg.Body = "hello abhi <br/>" + "<a href='www.unikainfocom.in'>More Details</a>" + "<br/><b>this is bold text!</b>";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(@"D:\\FeaturesContent.docx");
                Msg.Attachments.Add(attachment);
               //Msg.Attachments.Add(new Attachment("D:\\backup.zip"));

                Msg.IsBodyHtml = true;
                Msg.BodyEncoding = UTF8Encoding.UTF8;
                Msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(mailadd, pwd);
                smtp.EnableSsl = true;
                smtp.Send(Msg);

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
        }
    }
}
