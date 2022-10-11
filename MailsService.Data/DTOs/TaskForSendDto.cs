namespace MailsService.Data.DTOs
{
    public class TaskForSendDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> recipients { get; set; }
    }
}
