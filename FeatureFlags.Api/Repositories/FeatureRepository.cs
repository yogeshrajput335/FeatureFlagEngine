public class FeatureRepository : IFeatureRepository
{
    private readonly AppDbContext _db;

    public FeatureRepository(AppDbContext db)
    {
        _db = db;
    }

    public FeatureFlag? GetFeature(string key) =>
        _db.FeatureFlags.FirstOrDefault(f => f.Key == key);

    public FeatureOverrides GetOverrides(string key)
    {
        var result = new FeatureOverrides();

        var overrides = _db.FeatureOverrides
            .Where(o => o.FeatureKey == key)
            .ToList();

        foreach (var o in overrides)
        {
            var map = o.Level switch
            {
                OverrideLevel.User => result.User,
                OverrideLevel.Group => result.Group,
                OverrideLevel.Region => result.Region,
                _ => null
            };

            map![o.SubjectId] = o.Enabled;
        }

        return result;
    }
}
