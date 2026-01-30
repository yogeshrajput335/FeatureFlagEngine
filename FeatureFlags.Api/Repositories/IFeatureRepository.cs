public interface IFeatureRepository
{
    FeatureFlag? GetFeature(string key);
    FeatureOverrides GetOverrides(string key);
}
