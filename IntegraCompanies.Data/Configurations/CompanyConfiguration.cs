using IntegraCompanies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegraCompanies.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
                .HasOne(c => c.Connection)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.JurPerson)
                .WithMany(jp => jp.Companys)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(jp => jp.Name)
                .IsUnique();

            builder
                .OwnsOne(o => o.CompanyCounter)
                .ToTable("CompanyCounter");

            builder
                .OwnsOne(o => o.CompanyKvitok)
                .ToTable("CompanyKvitok");

            builder
                .OwnsOne(o => o.CompanyGis)
                .ToTable("CompanyGis");
        }
    }
}
