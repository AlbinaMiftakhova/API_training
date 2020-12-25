using API_training.DAL.Contexts;
using API_training.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace API_training.Services
{
    /// <summary>
    /// Сервис пользователи
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly ApiTrainingContext _apiTrainingContext;

        /// <summary>
        /// Конструктор <see cref="UserService"/>
        /// </summary>
        /// <param name="logger">Логгер</param>
        /// <param name="context">Контекст</param>
        public UserService(ILogger<UserService> logger, ApiTrainingContext context)
        {
            _logger = logger;
            _apiTrainingContext = context;
        }

        /// <summary>
        /// Проверка данных входа
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidUserCredentials(string userName, string password)
        {
            _logger.LogInformation($"Validating user [{userName}]");
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return _apiTrainingContext.Users.Any(x => x.Login == userName && x.Password == password);
        }

        /// <summary>
        /// Проверка на существование пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsAnExistingUser(string userName)
        {
            return _apiTrainingContext.Users.Any(x => x.Login == userName);
        }

        /// <summary>
        /// Получение роли пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetUserRole(string userName)
        {
            if (!IsAnExistingUser(userName))
            {
                return string.Empty;
            }

            var role = _apiTrainingContext.UserRoles
                .Include(x => x.User)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.User.Login == userName).Role?.Name;

            if (string.IsNullOrEmpty(role))
                throw new ArgumentNullException("Can't find role.");

            return role;
        }
    }
}
