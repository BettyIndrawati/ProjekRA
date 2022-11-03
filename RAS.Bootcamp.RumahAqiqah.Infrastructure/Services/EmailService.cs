using System.Net.Mime;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extentions.Configuration;

namespace RAS.Bootcamp.RumahAqiqah.Infrastructure;
public interface IEmailService{
    Task SendEmail(string email, string subject, string bodyEmail);
}

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
    public EmailService(IConfiguration _config)
    {
        _config = config;
    }
    public Task SendEmail(string email, string subject, string bodyEmail)
    {
        MimeMessage message = new MimeMessage();

        message.From.Add(new MailboxAddress(_config["EmailConfig:DisplayName"], _config["EmailConfig:Email"]));
        message.To.Add(MailboxAddress.Parse(email));
        message.Subject = subject;
        
        var builder = new BodyBuilder();

        builder.HtmlBody = bodyEmail;
        message.Body = builder.ToMessageBody();

        MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
        try
        {
            if(_config["EmailConfig:SecurityType"] == "StartTls"){
                
                await client.ConnectAsync(_config["EmailConfig:Host"], 
                int.Parse(_config["EmailConfig:Port"]), MailKit.Security.SecureSocketOptions.StartTls);
            
            }else{
                
                await client.ConnectAsync(_config["EmailConfig:Host"], 
                int.Parse(_config["EmailConfig:Port"]), true);
            }
            await client.AuthenticateAsync(_config["EmailConfig:Email"], _config["EmailConfig:Password"]);
            await client.SendAsync(message);
        }
        catch (Exception ex)
        {
            return $"Error on sending email: {ex.Message}";
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }   
    }
}
