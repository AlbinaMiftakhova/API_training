using System.Text.Json.Serialization;

namespace API_training.Infrastructure
{
    /// <summary>
    /// AT config from appconfig.
    /// </summary>
    public class JwtToken
    {
        /// <summary>
        /// Секретный ключ
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Издатель
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Audience
        /// </summary>
        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// Время истечения срока годности
        /// </summary>
        [JsonPropertyName("accessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        /// <summary>
        /// Время истечения срока годности рефреш токена
        /// </summary>
        [JsonPropertyName("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }
    }
}
