using MailsService.Model.Entities;

namespace MailsService.Data.DTOs
{
    public class SentReportDto : AuditModelDto<int>
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Email { get; set; }
        public ResultStatus Result { get; set; } = ResultStatus.ToSend;
        public string FailedMassage { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
    }
}
