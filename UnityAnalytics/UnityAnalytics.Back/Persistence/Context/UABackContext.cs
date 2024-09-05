using Microsoft.EntityFrameworkCore;
using UnityAnalytics.Back.Core.Domain;
using UnityAnalytics.Back.Persistence.Configurations;

namespace UnityAnalytics.Back.Persistence.Context;

public class UABackContext : DbContext
{
    public UABackContext(DbContextOptions<UABackContext> contextOptions): base(contextOptions)
    {
        
    }

    public DbSet<AppUser> AppUsersUsers => Set<AppUser>();
    public DbSet<AppRole> AppRoles => Set<AppRole>();
    
    public DbSet<Game> Games { get; set; }
    public DbSet<GameStats> GameStats { get; set; }
    public DbSet<CustomEvent> CustomEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new GameConfigurations());
    
        base.OnModelCreating(modelBuilder);
    }
}