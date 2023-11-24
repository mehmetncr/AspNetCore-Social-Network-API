using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_DataAccess.Repositories;
using AspNetCore_Social_DataAccess.UnitOfWorks;
using AspNetCore_Social_Entity.Repositories;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AspNetCore_Social_Service.Mapping;
using AspNetCore_Social_Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SocialContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
