using CommonCoreLayer.Entity.Concrete;
using CommonCoreLayer.Extenions;
using CommonCoreLayer.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CommonCoreLayer.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private TokenOptions tokenOptions;
        private DateTime accessTokenExpiration;
        private IConfiguration Configuration { get; }

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            accessTokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);
            var signingcredentials = SigningCredentialsHelper.CreateSigingCredentials(securityKey);
            var jwt = CreatejwtSecurityToken(tokenOptions, user, signingcredentials, operationClaims);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = accessTokenExpiration
            };
        }

        public JwtSecurityToken CreatejwtSecurityToken(TokenOptions tokenOptions,User user, SigningCredentials signingCredentials,
            List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user,operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            return claims;
        }
    }
}
