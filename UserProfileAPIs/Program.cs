using Microsoft.EntityFrameworkCore;
using UserProfileAPIs.Database;

var builder = WebApplication.CreateBuilder(args);

//Read configuration
var configValue = builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserProfileContext>(options =>
                options.UseSqlServer(configValue));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
