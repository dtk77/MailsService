using System.ComponentModel.DataAnnotations;

namespace MailsService.Model.Abstractions
{
    public abstract class BaseModel<TType>
    {
        [Key]
        public TType Id { get; set; }
    }
}
