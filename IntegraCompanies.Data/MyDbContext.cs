using IntegraCompanies.Data.Configurations;
using IntegraCompanies.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraCompanies.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyMask> CompanyMask { get; set; }
        public DbSet<Connection> Connection { get; set; }
        public DbSet<ConnectionServer> ConnectionServer { get; set; }
        public DbSet<JurPerson> JurPerson { get; set; }
        public DbSet<BillingReport> BillingReport { get; set; }
        public DbSet<SmtpServer> SmtpServer { get; set; }
        public DbSet<User> User { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new CompanyConfiguration());

            modelBuilder
                .ApplyConfiguration(new CompanyMaskConfiguration());

            modelBuilder
                .ApplyConfiguration(new ConnectionConfiguration());

            modelBuilder
                .ApplyConfiguration(new JurPersonConfiguration());

            modelBuilder
                .ApplyConfiguration(new JurPersonConfiguration());

            modelBuilder
                .ApplyConfiguration(new BillingReportConfiguration());
        }
    }
}
