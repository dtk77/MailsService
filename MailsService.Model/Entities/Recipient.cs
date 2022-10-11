using Microsoft.EntityFrameworkCore;

namespace MailsService.Model.Entities
{
    [Owned]
    public class Recipient
    {
        public string Email { get; set; } = string.Empty;
    }
}
