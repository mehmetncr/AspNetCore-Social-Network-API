using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_DataAccess.Repositories;
using AspNetCore_Social_DataAccess.UnitOfWorks;
using AspNetCore_Social_Entity.Repositories;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AspNetCore_Social_Service.Mapping;
using AspNetCore_Social_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtDefaults = configuration.GetSection("JwtDefaults");  //appsetting deki jwt verilerini almak için
            var secretKey = jwtDefaults["secretKey"]; //içinden secretKey i almak için
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {

                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,   //token üret
                    ValidateAudience = true,  //token denetle
                    ValidateLifetime = true,   //token ömür kontrolleri
                    ValidateIssuerSigningKey = true, //bizim verdiğimiz secret keyi kullan

                    ValidIssuer = jwtDefaults["ValidIssur"], //appsetting deki değeri alır
                    ValidAudience = jwtDefaults["ValidAudience"], //appsettingden değeri alır
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), //bizim verdiğimiz keyi encode eder
                    ClockSkew = TimeSpan.Zero //isteyen cihazla aradaki saat farkını sıfırlar
                };
            });


            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;  //karakter istemesin
                options.Password.RequiredLength = 3;  //uzunluğu en az 3 karakter olsun
                options.Password.RequireUppercase = false; //büyük harf istemesin
                options.Password.RequireLowercase = false;  //Küçük harf istemesin
                options.Password.RequireDigit = false; //sayı istemesin
                                                       //options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";  sadece bunlar kabul edilsin
                                                       //  options.User.RequireUniqueEmail = false; //e mail eşsisiz olmalı
                options.Lockout.MaxFailedAccessAttempts = 3;  //3 yanlış denemeden sonra girişi altaki süre kadar durdur
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);  // üstteki sayı kadaryanlış girişten sonra 1 dk girişi engeller

            }).AddEntityFrameworkStores<SocialContext>()
                    .AddDefaultTokenProviders();





            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            });

            services.ConfigureApplicationCookie(op =>
            {

                op.ExpireTimeSpan = TimeSpan.FromMinutes(100); //cookie ömrü dk
                                                               //op.AccessDeniedPath = new PathString("yetisi yok sayfası"); // yetkisi olmayinca yönlendirme
                op.SlidingExpiration = true; //üsstteki 10 dk dolmadan tekar login olursa tekrar süreyi başa alır
                op.Cookie = new CookieBuilder()
                {
                    Name = "SocialIdentityAppCookie", //cookie adı
                    HttpOnly = false,  //sadece tarayıcıdan girilsin programlar yakalayamayacak

                };

            });




            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IFriendService, FriendService>();
            services.AddScoped<IReplyCommentService, ReplyCommentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInterestService, InterestService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPrivacySettingsService, PrivacySettingsService>();
            services.AddScoped<IMessageService,MessageService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<INotificationService, NotificationService>();



        }
    }
}
