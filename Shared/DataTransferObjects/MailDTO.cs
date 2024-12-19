namespace Shared.DataTransferObjects.Mail;

public record MailDTO
{
    public string ToEmail { get; init; }
    public string Subject { get; init; }
    public string Body { get; init; }
    
};