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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
    
        base.OnModelCreating(modelBuilder);
    }
}