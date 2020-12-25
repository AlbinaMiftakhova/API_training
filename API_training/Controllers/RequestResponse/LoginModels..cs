using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_training.Controllers.RequestResponse
{
    /// <summary>
    /// Запрос
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    /// <summary>
    /// Ответ
    /// </summary>
    public class RequestResult
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// Настоящее имя полльзователя
        /// </summary>
        [JsonPropertyName("originalUserName")]
        public string OriginalUserName { get; set; }
        
        /// <summary>
        /// Токен
        /// </summary>
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Токен для обновления предыдущего токена
        /// </summary>
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }

    /// <summary>
    /// Запрос на обновление токена с истекшим сроком
    /// </summary>
    public class RefreshTokenRequest
    {
        /// <summary>
        /// Токен для обновления
        /// </summary>
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
    
}
