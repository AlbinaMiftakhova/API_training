namespace API_training.DAL.Models
{
    /// <summary>
    /// Роли пользователей
    /// </summary>
    public class UserRoles
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public Role Role { get; set; }
    }
}
