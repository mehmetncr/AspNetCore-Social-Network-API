using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        LoginDto login;
        public string GenereteToken(string userId)
        {
            var jwtDefaults = _configuration.GetSection("JwtDefaults");  //appsetting deki jwt verilerini almak için
            var secretKey = jwtDefaults["secretKey"]; //içinden secretKey i almak için

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
              new Claim(ClaimTypes.UserData, userId),
              new Claim(ClaimTypes.Name, userId),
              new Claim("sub", userId), // "sub" claim'i genellikle kullanıcı ID'sini temsil eder

             };


            JwtSecurityToken token = new JwtSecurityToken(issuer: jwtDefaults["ValidIssur"], audience: jwtDefaults["ValidAudience"], claims: claims, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtDefaults["expires"])), signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();  //token üreten,




            return handler.WriteToken(token);


        }
    }
}
