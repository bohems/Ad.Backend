using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence.Configuration
{
    public class AdvertisingConfiguration : IEntityTypeConfiguration<Advertising>
    {
        public void Configure(EntityTypeBuilder<Advertising> builder)
        {
            builder.HasKey(advertising => advertising.Id);

            builder.HasIndex(advertising => advertising.Id)
                .IsUnique();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(advertising => advertising.UserId);
        }
    }
}
