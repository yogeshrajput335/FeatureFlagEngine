public class FeatureFlagEngine
{
    private readonly IFeatureRepository _repo;

    public FeatureFlagEngine(IFeatureRepository repo)
    {
        _repo = repo;
    }

    public bool IsEnabled(string key, FeatureContext ctx)
    {
        var feature = _repo.GetFeature(key)
            ?? throw new Exception("Feature not found");

        var o = _repo.GetOverrides(key);

        if (ctx.UserId != null &&
            o.User.TryGetValue(ctx.UserId, out var u))
            return u;

        foreach (var g in ctx.GroupIds)
            if (o.Group.TryGetValue(g, out var gr))
                return gr;

        if (ctx.Region != null &&
            o.Region.TryGetValue(ctx.Region, out var r))
            return r;

        return feature.Enabled;
    }
}
