using System;
using System.Security.Claims;
using System.Threading.Tasks;
using API_training.Infrastructure;
using API_training.Services.Interfaces;
using API_training.Controllers.RequestResponse;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using API_training.Common;

namespace API_training.Controllers
{
    /// <summary>
    /// Контроллер авторизации и аутентификации
    /// </summary>
    [ApiController]
    [Authorize]
    //[ApiExplorerSettings(GroupName = DocumentPartsConst.User)]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;

        /// <summary>
        /// Конструктор <see cref="UserController"/>
        /// </summary>
        /// <param name="logger">Логгер</param>
        /// <param name="userService">Сервис</param>
        /// <param name="jwtAuthManager">Менеджер авторизации</param>
        public UserController(ILogger<UserController> logger, IUserService userService, IJwtAuthManager jwtAuthManager)
        {
            _logger = logger;
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }

        /// <summary>
        /// Выполнение входа
        /// </summary>
        /// <param name="request">Запрос на аутентификацию</param>
        /// <returns><see cref="ActionResult"/></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!_userService.IsValidUserCredentials(request.UserName, request.Password))
            {
                return Unauthorized();
            }
            var role = _userService.GetUserRole(request.UserName);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.UserName),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{request.UserName}] logged in the system.");
            return Ok(new RequestResult
            {
                UserName = request.UserName,
                Role = role,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.RT
            });
        }

        /// <summary>
        /// Получает текущего пользователя
        /// </summary>
        /// <returns><see cref="RequestResult"/></returns>
        [HttpGet("user")]
        [Authorize]
        public ActionResult GetCurrentUser()
        {
            var result = new RequestResult
            {
                UserName = User.Identity.Name,
                Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                OriginalUserName = User.FindFirst("OriginalUserName")?.Value
            };
            _logger.LogInformation($"Current user: [{result.UserName}], [{result.Role}], [{result.OriginalUserName}].");
            return Ok(result);
        }

        /// <summary>
        /// Выходит из учетной записи
        /// </summary>
        [HttpPost("logout")]
        [Authorize]
        public ActionResult Logout()
        {
            var userName = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserName(userName);
            _logger.LogInformation($"User [{userName}] logged out the system.");
            return Ok();
        }

        /// <summary>
        /// Обновление JWT-токена
        /// </summary>
        /// <param name="request"><see cref="RefreshTokenRequest"/></param>
        /// <returns><see cref="RequestResult"/></returns>
        [HttpPost("refreshToken")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var userName = User.Identity.Name;
                _logger.LogInformation($"User [{userName}] is trying to refresh JWT token.");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
                _logger.LogInformation($"User [{userName}] has refreshed JWT token.");
                return Ok(new RequestResult
                {
                    UserName = userName,
                    Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.RT
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
