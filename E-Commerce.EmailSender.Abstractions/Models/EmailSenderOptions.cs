using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.EmailSender.Abstractions.Models
{
    public sealed class EmailSenderOptions
    {
        public const string Key = "MailSender";

        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string SenderAddress { get; set; }
        public required string SenderName { get; set; }
        public required string SmtpServer { get; set; }
        public required int Port { get; set; }
    }
}
