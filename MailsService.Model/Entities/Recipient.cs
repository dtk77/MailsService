using Microsoft.EntityFrameworkCore;

namespace MailsService.Model.Entities
{
    [Owned]
    public class Recipient
    {
        public string email { get; set; } = string.Empty;
    }
}
