namespace MailsService.Data.DTOs
{
    public abstract class BaseModelDto<TType>
    {
        public TType Id { get; set; }
    }
}
