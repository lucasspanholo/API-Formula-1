using API_Formula1.Data;
using API_Formula1.Mapping;
using API_Formula1.Services;
using API_Formula1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IF1Service, F1Service>();
builder.Services.AddScoped<IMyDriversService, MyDriversService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.

//Documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
