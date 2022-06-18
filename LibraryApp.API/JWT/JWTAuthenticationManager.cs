using LibraryApp.API.Identity;
using LibraryApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace LibraryApp.API.JWT
{
    public  class JWTAuthenticationManager:IJWTAuthenticationService 
    {
        private readonly string _tokenKey;

        public JWTAuthenticationManager(string tokenKey)
        {
            _tokenKey = tokenKey;
        }

        public  string Authenticate(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //token will be user specific
            //token management
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("id",userId)
                    }),
                //open for 1 hour according to international time(for token)
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials=new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenKey)),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
