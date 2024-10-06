using MongoDB.Driver;
using Play.DbCatalog.Service.Settings;
using Play.DbCatalog.Service.Repositories;
using Play.DbCatalog.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceSettings serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>() ?? new ServiceSettings();

builder.Services.AddSingleton(serviceProvider =>
{
    var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>() ?? throw new InvalidOperationException("MongoDbSettings is not configured properly.");
    var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

    return mongoClient.GetDatabase(serviceSettings.ServiceName);
});

builder.Services.AddSingleton<ItemRepository, ItemRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();