using IntegraCompanies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegraCompanies.Data.Configurations
{
    public class ConnectionServerConfiguration : IEntityTypeConfiguration<ConnectionServer>
    {
        public void Configure(EntityTypeBuilder<ConnectionServer> builder)
        {
            builder
                .HasIndex(cs => cs.Name)
                .IsUnique();
        }
    }
}
