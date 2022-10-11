using MailKit.Security;
using MailsService.API;
using MailsService.Model.Entities;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Globalization;
using System.Text.RegularExpressions;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace MailsService.Data.Services;

public class EmailService : IEmailService
{
    private readonly MailSetting setting;

    public EmailService(IOptionsSnapshot<MailSetting> setting)
    {
        this.setting = setting.Value;
    }

    /// <summary>
    /// Sends an email asynchronously using SMTP
    /// </summary>
    public async Task<Tuple<ResultStatus, string>> SendEmailAsync(string toName,
                                                 string toAddress,
                                                 string subject,
                                                 string bodyText,
                                                 int retryCount = 3)
    {
        if (!IsValidEmail(toAddress))
            return Tuple.Create(item1: ResultStatus.Falied, item2: "Bad email address");

        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(setting.FromName, setting.FromAddress));
        message.To.Add(new MailboxAddress(toName, toAddress));
        message.Subject = subject;
        message.Body = new BodyBuilder { TextBody = bodyText }.ToMessageBody();

        for (var count = 1; count <= retryCount; count++)
        {
            try
            {
                using var client = new SmtpClient();
                SecureSocketOptions secureSocketOptions;

                if (!Enum.TryParse(setting.SecureSocketOption, out secureSocketOptions))
                {
                    secureSocketOptions = SecureSocketOptions.Auto;
                }

                int port = Convert.ToInt32(setting.Port);
                await client.ConnectAsync(setting.Host, port, secureSocketOptions).ConfigureAwait(false);
                client.Authenticate(setting.Username, setting.Password);

                await client.SendAsync(message).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);

                return Tuple.Create(
                item1: ResultStatus.Ok,
                item2: string.Empty);
            }
            catch (Exception ex)
            {
                if (count >= retryCount)
                {
                    return Tuple.Create(
                        item1: ResultStatus.Falied,
                        item2: ex.Message);
                }
                await Task.Delay(count * 1000);
            }

        }
        return Tuple.Create(
           item1: ResultStatus.Ok,
           item2: string.Empty);
    }



    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}
