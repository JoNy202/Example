using IntegraCompanies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegraCompanies.Data.Configurations
{
    public class BillingReportConfiguration : IEntityTypeConfiguration<BillingReport>
    {
        public void Configure(EntityTypeBuilder<BillingReport> builder)
        {
            builder
                .HasIndex(jp => jp.Name)
                .IsUnique();

            builder
                .HasIndex(jp => jp.FileName)
                .IsUnique();
        }
    }
}
