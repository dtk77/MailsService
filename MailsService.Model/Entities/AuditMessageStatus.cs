using MailsService.Model.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MailsService.Model.Entities
{
    [Owned]
    public class AuditMessageStatus
    {
        public ResultStatus Result { get; set; } = ResultStatus.ToSend;
        public string FailedMassage { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }
    }

    public enum ResultStatus : byte
    {
        [Display(Name = "Need to send")]
        ToSend,
        [Display(Name = "Ok")]
        Ok,
        [Display(Name = "Falied")]
        Falied
    }
}
