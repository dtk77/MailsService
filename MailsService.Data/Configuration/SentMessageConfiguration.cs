using MailsService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MailsService.Data.Configuration
{
    public class SentMessageConfiguration : IEntityTypeConfiguration<SentReport>
    {
        public void Configure(EntityTypeBuilder<SentReport> builder)
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

            builder.OwnsOne(e => e.Recipient).Property(x => x.Email)
                .HasColumnName("Recipient")
                .IsRequired()
                .HasMaxLength(260);

            builder.OwnsOne(e => e.MessageStatus).Property(x => x.Result)
                .IsRequired()
                .HasConversion(x => x.ToString(), x => (ResultStatus)Enum.Parse(typeof(ResultStatus), x))
                .HasColumnName("Result")
                .HasMaxLength(10); 
            
            builder.OwnsOne(e => e.MessageStatus).Property(x => x.FailedMassage)
                .IsRequired()
                .HasColumnName("FailedMassage")
                .HasMaxLength(500);

            builder.OwnsOne(e => e.MessageStatus).Property(x => x.SentDate)
                .IsRequired()
                .HasColumnName("SentDate");
        }
    }
}
