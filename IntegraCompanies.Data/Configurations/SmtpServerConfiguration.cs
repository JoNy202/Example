using IntegraCompanies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegraCompanies.Data.Configurations
{
    public class SmtpServerConfiguration : IEntityTypeConfiguration<SmtpServer>
    {
        public void Configure(EntityTypeBuilder<SmtpServer> builder)
        {
            builder
                .HasIndex(jp => jp.Name)
                .IsUnique();
        }
    }
}
