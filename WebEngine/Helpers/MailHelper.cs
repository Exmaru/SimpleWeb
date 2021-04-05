using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEngine
{
    public class MailHelper : IDisposable
    {
        private bool disposedValue;

        public MailHelper()
        {
        }

        public MailHelper(string smtpServer)
        {
            this.SetSMTPServer(smtpServer);
            this.client = new System.Net.Mail.SmtpClient(this.SmtpServerAddress);
            this.client.UseDefaultCredentials = false;
            this.client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        }

        public MailHelper(SMTPServers smtpServer)
        {
            this.SetSMTPServer(smtpServer);
            this.client = new System.Net.Mail.SmtpClient(this.SmtpServerAddress);
            this.client.UseDefaultCredentials = false;
            this.client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        }


        public string SmtpServerAddress { get; set; } = string.Empty;

        public int Port { get; set; } = 587;

        public bool IsSSL { get; set; } = true;

        protected string SenderMail { get; set; } = string.Empty;


        protected string _accountID { get; set; } = string.Empty;

        protected string _password { get; set; } = string.Empty;


        public string AccountID
        {
            get
            {
                return this._accountID;
            }
            set
            {
                this._accountID = value;
                if (!string.IsNullOrWhiteSpace(this._accountID) && !string.IsNullOrWhiteSpace(this._password))
                {
                    this.client.Credentials = new System.Net.NetworkCredential(this.AccountID, this.Password);
                }
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
                if (!string.IsNullOrWhiteSpace(this._accountID) && !string.IsNullOrWhiteSpace(this._password))
                {
                    
                }
            }
        }
        
        public void Login(string accountid, string password)
        {
            this._accountID = accountid;
            this._password = password;
            this.client.Credentials = new System.Net.NetworkCredential(this.AccountID, this.Password);
        }

        protected System.Net.Mail.MailMessage message { get; set; } = new System.Net.Mail.MailMessage();

        protected System.Net.Mail.SmtpClient client { get; set; }

        public System.Text.Encoding Encoding
        {
            get
            {
                return this.message.BodyEncoding;
            }
            set
            {
                this.message.BodyEncoding = value;
                this.message.SubjectEncoding = value;
            }
        }

        public string Subject
        {
            get
            {
                return this.message.Subject;
            }
            set
            {
                this.message.Subject = value;
            }
        }

        public string Body
        {
            get
            {
                return this.message.Body;
            }
            set
            {
                this.message.Body = value;
            }
        }

        public void SetBodyFromFile(string filePath)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
            if (fi.Exists)
            {
                string content = FileHelper.ReadFile(fi.FullName, System.Text.Encoding.UTF8);
                if (!string.IsNullOrWhiteSpace(content))
                {
                    this.message.Body = content;
                }
            }
        }

        public bool IsHtml
        {
            get
            {
                return this.message.IsBodyHtml;
            }
            set
            {
                this.message.IsBodyHtml = value;
            }
        }

        public string FromMail
        {
            get
            {
                return this.SenderMail;
            }
            set
            {
                this.SenderMail = value;
                this.message.From = new System.Net.Mail.MailAddress(this.SenderMail);
            }
        }

        public enum SMTPServers
        {
            [StringValue("smtp.naver.com")]
            NAVER, 
            [StringValue("smtp.gmail.com")]
            GOOGLE
        }

        public void SetSMTPServer(string smtpServer)
        {
            this.SmtpServerAddress = smtpServer;
        }

        public void SetSMTPServer(SMTPServers smtpServer)
        {
            this.SmtpServerAddress = smtpServer.GetStringValue();
        }


        public void AddFile(System.Net.Mail.Attachment item)
        {
            this.message.Attachments.Add(item);
        }

        public void AddFile(string fileName)
        {
            this.message.Attachments.Add(new System.Net.Mail.Attachment(fileName));
        }

        public ReturnValue Send(params string[] emails)
        {
            return this.Send(emails.ToList());
        }

        public ReturnValue Send(List<string> emails)
        {
            var result = new ReturnValue();

            try
            {
                if (emails != null && emails.Count > 0)
                {
                    foreach(string email in emails)
                    {
                        this.message.To.Add(email);
                    }
                    this.client.Send(this.message);
                    result.Success(emails.Count);
                }
                else
                {
                    result.Error("대상이 없습니다.");
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.client.Dispose();
                }

                disposedValue = true;
            }
        }

        ~MailHelper()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}