using Microsoft.EntityFrameworkCore;

namespace MailsService.Model.Entities
{
    [Owned]
    public class Message
    {
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}