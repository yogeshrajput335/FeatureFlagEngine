using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FeatureFlagsController : ControllerBase
{
    private readonly AppDbContext _db;

    public FeatureFlagsController(AppDbContext db) => _db = db;

    // GET: api/FeatureFlags
    [HttpGet]
    public IActionResult GetAll() => Ok(_db.FeatureFlags.ToList());

    // GET: api/FeatureFlags/{id}
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var feature = _db.FeatureFlags.Find(id);
        if (feature == null) return NotFound();
        return Ok(feature);
    }

    // POST: api/FeatureFlags
    [HttpPost]
    public IActionResult Create(FeatureFlag flag)
    {
        flag.Id = Guid.NewGuid();
        _db.FeatureFlags.Add(flag);
        _db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = flag.Id }, flag);
    }

    // PUT: api/FeatureFlags/{id}
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, FeatureFlag updated)
    {
        var feature = _db.FeatureFlags.Find(id);
        if (feature == null) return NotFound();

        feature.Key = updated.Key;
        feature.Enabled = updated.Enabled;
        feature.Description = updated.Description;

        _db.SaveChanges();
        return NoContent();
    }

    // DELETE: api/FeatureFlags/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var feature = _db.FeatureFlags.Find(id);
        if (feature == null) return NotFound();

        _db.FeatureFlags.Remove(feature);
        _db.SaveChanges();
        return NoContent();
    }
}
