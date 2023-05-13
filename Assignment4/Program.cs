using System.Reflection;
using Hearthstone.DataAccess.Configuration;
using Hearthstone.DataAccess.MongoDbServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection("MongoDbConfig"));
builder.Services.AddScoped<MongoDbService>();
builder.Services.AddScoped<CardService>();
builder.Services.AddScoped<ClassService>();
builder.Services.AddScoped<SetsService>();
builder.Services.AddScoped<RarityService>();
builder.Services.AddScoped<TypeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var seedService = services.GetRequiredService<MongoDbService>();

    await seedService.SeedMongoDb();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();