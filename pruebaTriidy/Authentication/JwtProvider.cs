using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace pruebaTriidy.Authentication
{
    public class JwtProvider : ITokenProvider
    {
        readonly RsaSecurityKey _Key;
        readonly string Algoritmo;
        readonly string Issuer;
        readonly string Audience;
        public JwtProvider(string issuer, string audience, string keyName)
        {
            var param = new CspParameters()
            {
                KeyContainerName = keyName
            };

            var provider = new RSACryptoServiceProvider(2048, param);

            _Key = new RsaSecurityKey(provider);
            Algoritmo = SecurityAlgorithms.RsaSha256Signature;
            Issuer = issuer;
            Audience = audience;



        }
        public string CreateToken( DateTime expiry)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();

            var identity = new ClaimsIdentity(new List<Claim>() {
                new Claim(ClaimTypes.Name,"City"),
                new Claim(ClaimTypes.Role,"Medellin"),
               
            }, "Customer");

            SecurityToken Token = TokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor()
            {
                Audience = Audience,
                Issuer = Issuer,
                SigningCredentials = new SigningCredentials(_Key, Algoritmo),
                Expires = expiry.ToUniversalTime(),
                Subject = identity
            });
            return TokenHandler.WriteToken(Token);
        }

        public TokenValidationParameters GetTokenValidation()
        {
            return new TokenValidationParameters()
            {
                IssuerSigningKey = _Key,
                ValidAudience = Audience,
                ValidIssuer = Issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }
    }
}
