using MailsService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MailsService.Data.Configuration
{
    public class SentMessageConfiguration : IEntityTypeConfiguration<SentMessage>
    {
        public void Configure(EntityTypeBuilder<SentMessage> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();

            builder.OwnsOne(e => e.Message).Property(p => p.Subject)
                .IsRequired()
                .HasColumnName("Subject")
                .HasMaxLength(200); 
            
            builder.OwnsOne(e => e.Message).Property(p => p.Body)
                .IsRequired()
                .HasColumnName("Body")
                .HasMaxLength(1000);

            builder.OwnsOne(e => e.Recipient).Property(x => x.email)
                .HasColumnName("Recipient")
                .IsRequired()
                .HasMaxLength(260);
            
            builder.OwnsOne(e => e.MessageStatus).Property(x => x.Result)
                .IsRequired()
                .HasColumnName("Result")
                .HasMaxLength(10); 
            
            builder.OwnsOne(e => e.MessageStatus).Property(x => x.FailedMassage)
                .IsRequired()
                .HasColumnName("FailedMassage")
                .HasMaxLength(200);

            builder.OwnsOne(e => e.MessageStatus).Property(x => x.SentDate)
                .IsRequired()
                .HasColumnName("SentDate");
        }
    }
}
