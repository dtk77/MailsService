namespace MailsService.Data.DTOs
{
    public abstract class AuditModelDto<TType> : BaseModelDto<TType> 
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
