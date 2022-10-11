using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MailsService.Data
{
    public class MailsServiceDbContextFactory : IDesignTimeDbContextFactory<MailsServiceDbContext>
    {
        public MailsServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MailsServiceDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=MailsServer;Trusted_Connection=True;MultipleActiveResultSets=True;");
            return new MailsServiceDbContext(optionsBuilder.Options);
        }
    }
}
