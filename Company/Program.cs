using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Domain.Models;
using Service.ServiceUnitOfWork;
using Repository.UnitOfWork;
using Domain.Common;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();
builder.Services.AddDbContext<ZzV10Context>();
#region Configration
var config=builder.Configuration;

SharedSettinges.FilePath = config.GetSection("SharedSettinges").GetValue<string>("FilePath");



#endregion

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
