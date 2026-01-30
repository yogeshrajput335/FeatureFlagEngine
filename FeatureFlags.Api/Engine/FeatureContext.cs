public class FeatureContext
{
    public string? UserId { get; init; }
    public IEnumerable<string> GroupIds { get; init; } = [];
    public string? Region { get; init; }
}