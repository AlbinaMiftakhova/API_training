namespace API_training.Services.Interfaces
{
    /// <summary>
    /// Интерфейс пользователи
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Проверка пользователя на сущствование
        /// </summary>
        bool IsAnExistingUser(string userName);

        /// <summary>
        /// Проверка данных входа
        /// </summary>
        bool IsValidUserCredentials(string userName, string password);

        /// <summary>
        /// Получение роли пользователя
        /// </summary>
        string GetUserRole(string userName);
    }
}
