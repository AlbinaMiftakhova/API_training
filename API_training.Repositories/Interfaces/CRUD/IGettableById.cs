using System.Threading.Tasks;

namespace API_training.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для получения сущности по идентификатору
    /// </summary>
    /// <typeparam name="TDto">DTO</typeparam>
    /// <typeparam name="TModel">Модель</typeparam>
    public interface IGettableById<TDto, TModel>
    {
        /// <summary>
        /// Получение сущности по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Экземпляр сущности</returns>
        Task<TDto> GetAsync(long id);
    }
}