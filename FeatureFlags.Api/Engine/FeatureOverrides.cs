public class FeatureOverrides
{
    public Dictionary<string, bool> User { get; } = new();
    public Dictionary<string, bool> Group { get; } = new();
    public Dictionary<string, bool> Region { get; } = new();
}