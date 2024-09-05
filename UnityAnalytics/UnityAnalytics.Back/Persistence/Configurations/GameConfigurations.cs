using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Persistence.Configurations;

public class GameConfigurations : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.GameId).IsRequired();
        builder.Property(g => g.Name).IsRequired();
        builder.Property(g => g.Description);
        

        builder.HasMany(g => g.GameStats)
            .WithOne(gs => gs.Game)
            .HasForeignKey(gs => gs.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.CustomEvents)
            .WithOne(ce => ce.Game)
            .HasForeignKey(ce => ce.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}