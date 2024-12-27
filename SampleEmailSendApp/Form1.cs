using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace SampleEmailSendApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendSampleEmail();
        }

        private void SendSampleEmail()
        {
            try
            {
                
                string senderEmail = "prabuddha.das.ext@evidentscientific.com"; 
                string senderPassword = "Kitumiinfy@1234";       
                string recipientEmail = "martin.fu.ext@evidentscientific.com"; 
                string subject = "Test Email";
                string body = "Hi Martin";

                
                SmtpClient smtpClient = new SmtpClient("smtp.gss.local", 587)
                {
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true 
                };

                
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false 
                };

                // Add the recipient
                mailMessage.To.Add(recipientEmail);

                // Send the email
                smtpClient.Send(mailMessage);

                MessageBox.Show("Sample email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
        }
    }
}
