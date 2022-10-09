using MailsService.Model.Abstractions;

namespace MailsService.Model.Entities
{
    /// <summary>
    /// This object is a report line for db
    /// </summary>
    /// <remarks></remarks>
    public class SentMessage : AuditModel<int>
    {
        public Message? Message { get; set; }
        public Recipient? Recipient { get; set; }
        public AuditMessageStatus? MessageStatus { get; set; }
    }
}
