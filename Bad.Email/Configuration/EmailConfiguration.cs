using Microsoft.Extensions.Configuration;
using System;

namespace Bad.Email.Models
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public EmailConfiguration(IConfiguration configuration)
        {
            FromAddress = configuration["SMTP:FromAddress"];
            FromName = configuration["SMTP:FromName"];
            SmtpServer = configuration["SMTP:Server"];
            Port = Convert.ToInt16(configuration["SMTP:Port"]);
            UserName = configuration["SMTP:Username"];
            Password = configuration["SMTP:Password"];
        }
    }
}
