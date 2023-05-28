using Amazon.SimpleEmailV2;
using EventMaster.Application.Common.Interfaces.Services;

namespace EventMaster.Infrastructure.Services;

public class EmailProvider : IEmailProvider
{
    private readonly IAmazonSimpleEmailServiceV2 _emailService;

    public EmailProvider(IAmazonSimpleEmailServiceV2 emailService)
    {
        _emailService = emailService;
    }

    public async Task SendEmail(string from, List<string> to, string subject, string message, List<string>? cc)
    {
        await _emailService.SendEmailAsync(new Amazon.SimpleEmailV2.Model.SendEmailRequest
        {
            Content = new Amazon.SimpleEmailV2.Model.EmailContent
            {
                Simple = new Amazon.SimpleEmailV2.Model.Message
                {
                    Body = new Amazon.SimpleEmailV2.Model.Body
                    {
                        Html = new Amazon.SimpleEmailV2.Model.Content
                        {
                            Charset = "UTF-8",
                            Data = message
                        }
                    },
                    Subject = new Amazon.SimpleEmailV2.Model.Content
                    {
                        Charset = "UTF-8",
                        Data = subject
                    }
                }
            },
            Destination = new Amazon.SimpleEmailV2.Model.Destination
            {
                ToAddresses = to,
                CcAddresses = cc
            },
            FromEmailAddress = from
        });
    }
}