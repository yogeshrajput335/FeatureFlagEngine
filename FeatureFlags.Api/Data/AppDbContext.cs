using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<FeatureFlag> FeatureFlags => Set<FeatureFlag>();
    public DbSet<FeatureOverride> FeatureOverrides => Set<FeatureOverride>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<FeatureFlag>()
            .HasIndex(f => f.Key)
            .IsUnique();

        b.Entity<FeatureOverride>()
            .HasIndex(o => new { o.FeatureKey, o.Level, o.SubjectId })
            .IsUnique();
    }
}
