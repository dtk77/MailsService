using MailsService.Model.Abstractions;

namespace MailsService.Model.Entities
{
    public class SentMessage : AuditModel<int>
    {
        public Message Message { get; set; }
        public Recipient Recipient { get; set; }
        public AuditMessageStatus MessageStatus { get; set; }

        public SentMessage(Message message, Recipient recipient, AuditMessageStatus messageStatus)
        {
            Message = message;
            Recipient = recipient;
            MessageStatus = messageStatus;
        }
    }
}
