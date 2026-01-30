public class FeatureFlag
{
    public Guid Id { get; set; }
    public string Key { get; set; } = default!;
    public bool Enabled { get; set; }
    public string? Description { get; set; }
}
