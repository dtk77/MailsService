namespace MailsService.Model.Abstractions
{
    public abstract class AuditModel<TType> : BaseModel<TType>
    {

        /// <summary>
        /// Tracks when this entity was first persisted to the database.
        /// </summary>
        public DateTime CreatedDate { get; internal set; }


        /// <summary>
        /// Tracks when this entity was last updated.
        /// </summary>
        public DateTime UpdatedDate { get; internal set; }
    }
}
