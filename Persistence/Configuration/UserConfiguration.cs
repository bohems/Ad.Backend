using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.HasIndex(user => user.Id)
                .IsUnique();

            builder.Property(user => user.Username)
                .HasMaxLength(20);
        }
    }
}
