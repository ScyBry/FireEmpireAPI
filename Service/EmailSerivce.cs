using AutoMapper;
using Contracts;
using MailKit.Security;
using MimeKit;
using Service.Contracts;
using Shared.DataTransferObjects.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Service;

public class EmailService : IEmailService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly string _smtpHost;
    private readonly string _smtpPassword;
    private readonly int _smtpPort;
    private readonly string _smtpUser;

    public EmailService(ILoggerManager logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;

        _smtpHost = Environment.GetEnvironmentVariable("SMTP_HOST");
        _smtpPort = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT"));
        _smtpUser = Environment.GetEnvironmentVariable("SMTP_MAIL");
        _smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
    }

    public async Task SendFeedbackEmailAsync(MailDTO mailDto)
    {
        // Загрузка HTML-шаблона
        var htmlBody = await GetEmailTemplateAsync();

        // Использование string.Format для замены {0} в шаблоне
        var messageBody = htmlBody.Replace("{0}", mailDto.Body);


        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Your Name", _smtpUser));
        emailMessage.To.Add(new MailboxAddress("", mailDto.ToEmail));
        emailMessage.Subject = mailDto.Subject;
        emailMessage.Body = new TextPart("html") { Text = messageBody };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_smtpHost, _smtpPort, SecureSocketOptions.SslOnConnect);
            await client.AuthenticateAsync(_smtpUser, _smtpPassword);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }

    private async Task<string> GetEmailTemplateAsync()
    {
        // Просто загружаем шаблон из файла
        var pathToFile = Path.Combine(Directory.GetCurrentDirectory(),
            "Tempates/Email/FeedbackEmail.html");
        var htmlBody = await File.ReadAllTextAsync(pathToFile);
        return htmlBody;
    }
}