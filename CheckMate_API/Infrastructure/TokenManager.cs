using CheckMate_API.Models;
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
        #region Propriétés et Constructeurs
        private readonly string _issuer, _audience, _secret;

        /// <summary>
        /// Permet de récupérer à l'instanciation du TokenManager les information contenue dans le fichier AppSettings.Json.
        /// </summary>
        /// <param name="config">Collection contenant les information du fichier AppSettings.Json</param>
        public TokenManager(IConfiguration config)
        {
            _issuer = config.GetSection("TokenInfo").GetSection("issuer").Value;
            _audience = config.GetSection("TokenInfo").GetSection("audience").Value;
            _secret = config.GetSection("TokenInfo").GetSection("secret").Value;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Permet de générer un Token sur base d'un Member.
        /// </summary>
        /// <param name="m">Member dont on veut récupérer le Token</param>
        /// <returns>Un Token sous forme d'un JWT. Une fois décrypté, le Member se retrouve sous forme d'un Json.</returns>
        /// <exception cref="ArgumentNullException">Exception levée si la méthode est appelée avec un Member null en paramètre.</exception>
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
        #endregion
    }
}