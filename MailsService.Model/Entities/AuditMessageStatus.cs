using MailsService.Model.Abstractions;

namespace MailsService.Model.Entities
{
    public class AuditMessageStatus
    {
        public ResultStatus Result { get; set; } = ResultStatus.None;
        public string FailedMassage { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
    }

    public enum ResultStatus
    {
        None,
        Ok,
        False
    }
}
