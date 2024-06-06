using Kolos2_1.Entities;
using Kolos2_1.Repositories;
using Kolos2_1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<ITripService, TripService>();

//dotnet new tool-manifest
//dotnet tool install dotnet-ef
//dotnet ef migrations add Init
//dotnet ef database update

//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Design

builder.Services.AddDbContext<TravelDbContext>(opt =>
{
    string connString = builder.Configuration.GetConnectionString("Default");
    opt.UseSqlServer(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

