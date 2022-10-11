using MailsService.Data.Configuration;
using MailsService.Model.Abstractions;
using MailsService.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailsService.Data
{
    public class MailsServiceDbContext : DbContext
    {
        public MailsServiceDbContext(DbContextOptions<MailsServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<SentReport> SentReport { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SentMessageConfiguration());
        }


        public override int SaveChanges()
        {
            SetupAuditTrail();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetupAuditTrail();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetupAuditTrail();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetupAuditTrail()
        {
            var dtNow = DateTime.Now;
            foreach(var entry in ChangeTracker.Entries().Where(
                e=>e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity is AuditModel<int>)
                {
                    var entity = entry.Entity as AuditModel<int>;
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedDate = entity.UpdatedDate = dtNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entity.UpdatedDate = dtNow;
                    }
                }
            }
        }




    }
}
