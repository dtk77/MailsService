using MailsService.Model.Entities;

namespace MailsService.Data.Services
{
    public interface IEmailService
    {
        Task<Tuple<ResultStatus, string>> SendEmailAsync(string toName,
                                                     string toAddress,
                                                     string subject,
                                                     string bodyText,
                                                     int retryCount = 3);
    }
}
