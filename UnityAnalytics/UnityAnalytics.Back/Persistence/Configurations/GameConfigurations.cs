using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Persistence.Configurations;

public class GameConfigurations : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder
            .HasMany(g => g.GameStats)
            .WithOne(gs => gs.Game)
            .HasForeignKey(gs => gs.GameId);

        builder
            .HasMany(g => g.CustomEvents)
            .WithOne(ce => ce.Game)
            .HasForeignKey(ce => ce.GameId);
    }
}