using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class EvaluateController : ControllerBase
{
    private readonly FeatureFlagEngine _engine;

    public EvaluateController(FeatureFlagEngine engine)
    {
        _engine = engine;
    }

    [HttpPost("evaluate")]
    public IActionResult Evaluate(EvaluateRequest req)
    {
        var enabled = _engine.IsEnabled(
            req.FeatureKey,
            new FeatureContext
            {
                UserId = req.UserId,
                GroupIds = req.GroupIds ?? [],
                Region = req.Region
            });

        return Ok(new { enabled });
    }
}

public record EvaluateRequest(
    string FeatureKey,
    string? UserId,
    List<string>? GroupIds,
    string? Region
);
