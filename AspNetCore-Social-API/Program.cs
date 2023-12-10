using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_Service.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExtensions();

builder.Services.AddDbContext<SocialContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

builder.Services.AddCors(cors => cors.AddDefaultPolicy(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())

    );

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
});



var app = builder.Build();

app.UseCors();
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
