using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence.Configuration
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(ad => ad.Id);

            builder.HasIndex(ad => ad.Id)
                .IsUnique();

            builder.HasIndex(ad => ad.Number);

            builder.HasIndex(ad => ad.Rating);

            builder.HasIndex(ad => ad.CreationDate);

            builder.HasIndex(ad => ad.ExpiryDate);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(ad => ad.UserId);

        }
    }
}
