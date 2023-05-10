using System.Reflection;
using Hearthstone.DataAccess.Configuration;
using Hearthstone.DataAccess.MongoDbServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection("MongoDbConfig"));
builder.Services.AddSingleton<SeedService>();
builder.Services.AddSingleton<CardService>();
builder.Services.AddSingleton<ClassService>();
builder.Services.AddSingleton<SetsService>();
builder.Services.AddSingleton<RarityService>();
builder.Services.AddSingleton<TypeService>();

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