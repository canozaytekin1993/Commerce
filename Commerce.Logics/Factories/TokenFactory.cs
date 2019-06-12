using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Domain.Configurations.Auth;
using Commerce.Extensions.Constants;
using Microsoft.Extensions.Options;

namespace Commerce.Logics.Factories
{
    public class TokenFactory : ITokenFactory
    {
        private readonly JwtIssuerOptions _issuerOptions;

        public TokenFactory(IOptions<JwtIssuerOptions> issuerOptions)
        {
            _issuerOptions = issuerOptions.Value;
            throwInvalidOptions(_issuerOptions);
        }

        public async Task<string> GenerateIdentityToken(string username, ClaimsIdentity identity)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, await _issuerOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_issuerOptions.IssueDate).ToString(),
                    ClaimValueTypes.Integer64),
                identity.FindFirst(ClaimIdentifiers.Role),
                identity.FindFirst(ClaimIdentifiers.Id)
            };
            var jwt = new JwtSecurityToken(_issuerOptions.Issuer, _issuerOptions.Audience, claims,
                _issuerOptions.NotBefore, _issuerOptions.Expiration, _issuerOptions.SigningCredentials);
            var encodedjwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedjwt;
        }

        public ClaimsIdentity GenerateuserIdentity(string username, string id)
        {
            return new ClaimsIdentity(new GenericIdentity(username, "Token"), new[]
            {
                new Claim(ClaimIdentifiers.Id, id),
                new Claim(ClaimIdentifiers.Role, JwtClaims.ApiAccess)
            });
        }

        private void throwInvalidOptions(JwtIssuerOptions issuerOptions)
        {
            if (issuerOptions == null) throw new ArgumentException(nameof(issuerOptions));
            if (issuerOptions.ValidUnit <= TimeSpan.Zero)
                throw new ArgumentNullException("Token expiration must be greater than zero");
            if (issuerOptions.SigningCredentials == null)
                throw new ArgumentNullException(nameof(issuerOptions.SigningCredentials));
            if (issuerOptions.JtiGenerator == null) throw new ArgumentNullException(nameof(issuerOptions.JtiGenerator));
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long) Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);
        }
    }
}