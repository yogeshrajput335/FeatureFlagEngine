public enum OverrideLevel { User, Group, Region }

public class FeatureOverride
{
    public Guid Id { get; set; }
    public string FeatureKey { get; set; } = default!;
    public OverrideLevel Level { get; set; }
    public string SubjectId { get; set; } = default!;
    public bool Enabled { get; set; }
}
