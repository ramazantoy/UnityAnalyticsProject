using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Persistence.Configurations;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasKey(ar => ar.Id);
        builder.Property(ar => ar.Definition).IsRequired();

        builder.HasMany(ar => ar.AppUsers)
            .WithOne(au => au.AppRole)
            .HasForeignKey(au => au.AppRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}