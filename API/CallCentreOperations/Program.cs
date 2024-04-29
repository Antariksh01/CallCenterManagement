using CallCentreOperations.Data;
using CallCentreOperations.Data.Interface;
using CallCentreOperations.Service;
using CallCentreOperations.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

var builder = WebApplication.CreateBuilder(args);
var connectionStringPostgress = builder.Configuration.GetConnectionString("PostgressSQL");
var connectionStringMongoDb = builder.Configuration.GetConnectionString("MongoDb");
var config = builder.Configuration;


// Add services to the container.
builder.Services.AddControllers();

// Check for DB provider
builder.Services.AddScoped<IDataContext>(provider1 =>
{
    var provider = builder.Configuration.GetValue<string>("Database:Provider");
    if (provider == "Postgress")
    {
        var connectionString = builder.Configuration.GetConnectionString("PostgressConnection");
        return new PostgressDataContext(new DbContextOptionsBuilder<PostgressDataContext>().UseNpgsql(connectionString).Options);
    }
    if (provider == "MongoDb")
    {
        var connectionString = builder.Configuration.GetConnectionString("MongoDbConnection");
        return new MongoDbDataContext(new DbContextOptionsBuilder<MongoDbDataContext>().UseMongoDB(connectionString,"CallCenter").Options);
    }
    throw new NotSupportedException($"Provider '{provider}' is not supported.");
});

builder.Services.AddScoped<IAgentService, AgentService>();

//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:5173")
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
