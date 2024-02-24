using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlatfromService.Data;
using PlatfromService.SyncDataService.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options=> options.UseInMemoryDatabase("InMemo"));
builder.Services.AddScoped<IPlatformRepo, PlatfromRepo>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
// Add services to the container.
Console.WriteLine($"-->Command service Endpoint {builder.Configuration["CommandService"]}");
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

app.UseHttpsRedirection();

app.UseAuthorization();

PrepDb.PrepPopulation(app);

app.MapControllers();

app.Run();
