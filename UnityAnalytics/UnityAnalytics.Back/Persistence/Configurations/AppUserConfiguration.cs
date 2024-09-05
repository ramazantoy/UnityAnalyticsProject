using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(au => au.Id);
        builder.Property(au => au.UserName).IsRequired();
        builder.Property(au => au.Password).IsRequired();
        builder.Property(au => au.CreatedAt).IsRequired();

        builder.HasOne(au => au.AppRole)
            .WithMany(ar => ar.AppUsers)
            .HasForeignKey(au => au.AppRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(au => au.Games).WithOne(g => g.AppUser).HasForeignKey(g => g.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}