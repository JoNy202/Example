using IntegraCompanies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegraCompanies.Data.Configurations
{
    public class CompanyMaskConfiguration : IEntityTypeConfiguration<CompanyMask>
    {
        public void Configure(EntityTypeBuilder<CompanyMask> builder)
        {
            builder
                .HasOne(cm => cm.Company)
                .WithMany(c => c.CompanyMasks);

            builder
                .HasIndex(cm => cm.CompanyId);

            builder
                .HasIndex(cm => cm.Mask);

            builder
                .HasIndex(cm => new { cm.CompanyId, cm.Mask })
                .IsUnique();
        }
    }
}
