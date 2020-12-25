using System;
using System.Text.Json.Serialization;

namespace API_training.Infrastructure
{
    /// <summary>
    /// Модель рефреш токена
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        [JsonPropertyName("tokenString")]
        public string RT { get; set; }

        /// <summary>
        /// Время окончания действия
        /// </summary>
        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}
