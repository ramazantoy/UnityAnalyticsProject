using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnityAnalytics.Back.Core.Domain;

namespace UnityAnalytics.Back.Persistence.Configurations;

public class CustomEventConfiguration : IEntityTypeConfiguration<CustomEvent>
{
    public void Configure(EntityTypeBuilder<CustomEvent> builder)
    {
        builder.HasKey(ce => ce.Id);
        builder.Property(ce => ce.EventName).IsRequired();
        builder.Property(ce => ce.EventData).IsRequired();
        builder.Property(ce => ce.EventTime).IsRequired();
        builder.Property(ce => ce.GameId).IsRequired();

        builder.HasOne(ce => ce.Game)
            .WithMany(g => g.CustomEvents)
            .HasForeignKey(ce => ce.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}