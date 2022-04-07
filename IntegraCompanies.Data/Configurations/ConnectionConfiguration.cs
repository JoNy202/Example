using IntegraCompanies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegraCompanies.Data.Configurations
{
    public class ConnectionConfiguration : IEntityTypeConfiguration<Connection>
    {
        public void Configure(EntityTypeBuilder<Connection> builder)
        {
            builder
                .HasOne(c => c.ConnectionServer)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(c => new { c.ConnectionServerId, c.DatabaseName })
                .IsUnique();
        }
    }
}
