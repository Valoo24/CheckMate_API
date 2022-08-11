﻿using CheckMate_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CheckMate_API.Infrastructure
{
    /// <summary>
    /// Classe qui permet de gérer les Tokens.
    /// </summary>
    public class TokenManager
    {
        private readonly string _issuer, _audience, _secret;

        public TokenManager(IConfiguration config)
        {
            _issuer = config.GetSection("TokenInfo").GetSection("issuer").Value;
            _audience = config.GetSection("TokenInfo").GetSection("audience").Value;
            _secret = config.GetSection("TokenInfo").GetSection("secret").Value;
        }

        public string GenerateToken(Member m)
        {
            if (m is null) throw new ArgumentNullException();

            //Créer la signin key 
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Création du payload / info utilisateur
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Surname, m.Pseudo),
                new Claim(ClaimTypes.Sid, m.MemberId.ToString()),
                new Claim(ClaimTypes.Role, m.IsAdmin ? "Admin" : "User"),
                new Claim(ClaimTypes.Gender, m.Gender),
                new Claim(ClaimTypes.DateOfBirth, m.Birthdate.ToString()),
                new Claim(ClaimTypes.Version, m.Elo.ToString())
            };

            //Configuration du token
            JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: credentials,
                    issuer: _issuer,
                    audience: _audience,
                    expires: DateTime.Now.AddDays(1)
                );

            //Génération du token

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}
