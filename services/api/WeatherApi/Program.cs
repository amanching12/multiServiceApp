using WeatherApi.AppSettings;
using WeatherApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CacheConfig>(builder.Configuration.GetSection("CacheConfig"));
builder.Services.Configure<DBConfig>(builder.Configuration.GetSection("DatabaseConfig"));
builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddSingleton<RedisCacheService>();
builder.Services.AddSingleton<DataSeeder>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Call the DataSeeder here to populate the MongoDB with initial data
var seeder = app.Services.GetRequiredService<DataSeeder>();
await seeder.SeedDataAsync();  // Seed data on application startup


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();