using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;

namespace API_training.Infrastructure
{
    /// <summary>
    /// Интерфейс менеджера аутентификации
    /// </summary>
    public interface IJwtAuthManager
    {
        /// <summary>
        /// Словарь рефреш-токенов
        /// </summary>
        IImmutableDictionary<string, RefreshToken> UsersRefreshTokens { get; }

        /// <summary>
        /// Создание токена
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="claims">Claims</param>
        /// <param name="now">Время создания</param>
        /// <returns><see cref="JwtResult"/></returns>
        JwtResult GenerateTokens(string username, Claim[] claims, DateTime now);

        /// <summary>
        /// овление токена
        /// </summary>
        /// <param name="refreshToken">рефреш токен</param>
        /// <param name="accessToken">AT</param>
        /// <param name="now">Время создания</param>
        /// <returns></returns>
        JwtResult Refresh(string refreshToken, string accessToken, DateTime now);

        /// <summary>
        /// Удаление рефреш токена
        /// </summary>
        /// <param name="now">Время</param>
        void RemoveExpiredRT(DateTime now);

        /// <summary>
        /// Обновление токена конкретного пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        void RemoveRefreshTokenByUserName(string userName);

        /// <summary>
        /// Декодирование токена
        /// </summary>
        /// <param name="token">AT</param>
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }

    /// <summary>
    /// Менеджер аутентификации
    /// </summary>
    public class JwtAuthManager : IJwtAuthManager
    {
        public IImmutableDictionary<string, RefreshToken> UsersRefreshTokens => _usersRefreshTokens.ToImmutableDictionary();
        private readonly ConcurrentDictionary<string, RefreshToken> _usersRefreshTokens; 
        private readonly JwtToken _JwtToken;
        private readonly byte[] _secret;

        /// <summary>
        /// Конструктор <see cref="JwtAuthManager"/>
        /// </summary>
        /// <param name="JwtToken"><see cref="JwtToken"/></param>
        public JwtAuthManager(JwtToken JwtToken)
        {
            _JwtToken = JwtToken;
            _usersRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
            _secret = Encoding.ASCII.GetBytes(JwtToken.Secret);
        }

        /// <summary>
        /// Удаление рефреш токенов с истекшим сроком
        /// </summary>
        /// <param name="now"></param>
        public void RemoveExpiredRT(DateTime now)
        {
            var expiredTokens = _usersRefreshTokens.Where(x => x.Value.ExpireAt < now).ToList();
            foreach (var expiredToken in expiredTokens)
            {
                _usersRefreshTokens.TryRemove(expiredToken.Key, out _);
            }
        }

        /// <summary>
        /// Удаление рефреш токена по имени пользователя
        /// </summary>
        /// <param name="userName"></param>
        public void RemoveRefreshTokenByUserName(string userName)
        {
            var refreshTokens = _usersRefreshTokens.Where(x => x.Value.UserName == userName).ToList();
            foreach (var refreshToken in refreshTokens)
            {
                _usersRefreshTokens.TryRemove(refreshToken.Key, out _);
            }
        }

        /// <summary>
        /// Создание токена
        /// </summary>
        /// <param name="username"></param>
        /// <param name="claims"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public JwtResult GenerateTokens(string username, Claim[] claims, DateTime now)
        {
            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
            // set needed params in appconfig (if you need, of course :) ) 
            var jwtToken = new JwtSecurityToken(
                _JwtToken.Issuer,
                shouldAddAudienceClaim ? _JwtToken.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(_JwtToken.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var refreshToken = new RefreshToken
            {
                UserName = username,
                RT = GenerateRefreshTokenString(),
                ExpireAt = now.AddMinutes(_JwtToken.RefreshTokenExpiration)
            };
            _usersRefreshTokens.AddOrUpdate(refreshToken.RT, refreshToken, (s, t) => refreshToken);

            return new JwtResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        /// <summary>
        /// Обновление токена 
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="accessToken"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public JwtResult Refresh(string refreshToken, string accessToken, DateTime now)
        {
            var (principal, jwtToken) = DecodeJwtToken(accessToken);
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                throw new SecurityTokenException("Invalid token");
            }

            var userName = principal.Identity.Name;
            if (!_usersRefreshTokens.TryGetValue(refreshToken, out var existingRefreshToken))
            {
                throw new SecurityTokenException("Invalid token");
            }
            if (existingRefreshToken.UserName != userName || existingRefreshToken.ExpireAt < now)
            {
                throw new SecurityTokenException("Invalid token");
            }

            return GenerateTokens(userName, principal.Claims.ToArray(), now); // need to recover the original claims
        }

        /// <summary>
        /// Расшифровка токена
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new SecurityTokenException("Invalid token");
            }
            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = _JwtToken.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(_secret),
                        ValidAudience = _JwtToken.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(1)
                    },
                    out var validatedToken);
            return (principal, validatedToken as JwtSecurityToken);
        }

        /// <summary>
        /// Создание рефреш токена
        /// </summary>
        /// <returns></returns>
        private static string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
