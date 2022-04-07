using IntegraCompanies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegraCompanies.Data.Configurations
{
    public class JurPersonConfiguration : IEntityTypeConfiguration<JurPerson>
    {
        public void Configure(EntityTypeBuilder<JurPerson> builder)
        {
            builder
                .HasIndex(jp => jp.Name)
                .IsUnique();
        }
    }
}
