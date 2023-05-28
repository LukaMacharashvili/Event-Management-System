namespace EventMaster.Application.Common.Interfaces.Services;

public interface IEmailProvider
{
    Task SendEmail(string from, List<string> to, string subject, string message, List<string>? cc);
}