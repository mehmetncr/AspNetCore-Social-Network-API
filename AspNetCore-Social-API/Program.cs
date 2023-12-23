using AspNetCore_Social_API.Controllers.Hubs;
using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_Service.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddDbContext<SocialContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

builder.Services.AddCors(cors => cors.AddDefaultPolicy(cors => cors
.WithOrigins("https://localhost:7184")
.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials()
));

builder.Services.AddExtensions(builder.Configuration);





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
app.MapHub<MessageHub>("/MessageHub");
app.Run();
