using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
// Add services to container
// ----------------------

// Add EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=flags.db"));

// Add repositories/services
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<FeatureFlagEngine>();

// Add Controllers
builder.Services.AddControllers();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// ----------------------
// Configure middleware
// ----------------------

// Enable Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAll");

// Map Controllers
app.MapControllers();

app.Run();