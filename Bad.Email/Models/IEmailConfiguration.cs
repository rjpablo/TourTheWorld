namespace Bad.Email.Models
{
    public interface IEmailConfiguration
    {
        string FromAddress { get; set; }
        string FromName { get; set; }
        string SmtpServer { get; set; }
        int Port { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
