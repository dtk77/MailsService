using MailsService.Model.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MailsService.Model.Entities
{
    [Owned]
    public class AuditMessageStatus
    {
        public ResultStatus Result { get; set; } = ResultStatus.None;
        public string FailedMassage { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
    }

    public enum ResultStatus : byte
    {
        None,
        Ok,
        False
    }
}
