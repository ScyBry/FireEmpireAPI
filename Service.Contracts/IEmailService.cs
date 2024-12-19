using Shared.DataTransferObjects.Mail;

namespace Service.Contracts;

public interface IEmailService
{
    Task SendFeedbackEmailAsync(MailDTO mailDTO);
}