using GreenHarborApi.Interfaces;
using GreenHarborApi.Models;
using GreenHarborApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<GreenHarborApiContext>(
                    dbContextOptions => dbContextOptions
                        .UseMySql(
                        builder.Configuration["ConnectionStrings:DefaultConnection"], 
                        ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                        )
                    )
                );

builder.Services.AddScoped<ICompostRepository, CompostRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else 
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();