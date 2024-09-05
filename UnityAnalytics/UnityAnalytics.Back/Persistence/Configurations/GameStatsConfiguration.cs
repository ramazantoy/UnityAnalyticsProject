using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Persistence.Configurations;

public class GameStatsConfiguration : IEntityTypeConfiguration<GameStats>
{
    public void Configure(EntityTypeBuilder<GameStats> builder)
    {
        builder.HasKey(gs => gs.Id);
        builder.Property(gs => gs.TotalPlays).IsRequired();
        builder.Property(gs => gs.UniqueUsers).IsRequired();
        builder.Property(gs => gs.AveragePlayTime).IsRequired();
        builder.HasOne(gs => gs.Game)
            .WithMany(g => g.GameStats)
            .HasForeignKey(gs => gs.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}