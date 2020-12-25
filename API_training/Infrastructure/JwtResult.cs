using System.Text.Json.Serialization;

namespace API_training.Infrastructure
{
    /// <summary>
    /// Ответ
    /// </summary>
    public class JwtResult
    {
        /// <summary>
        /// Токен
        /// </summary>
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Рефреш токен
        /// </summary>
        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }

}
