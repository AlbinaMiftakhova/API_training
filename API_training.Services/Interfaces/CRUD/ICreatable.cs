using System.Threading.Tasks;

namespace API_training.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для создания сущности
    /// </summary>
    /// <typeparam name="TDto">DTO</typeparam>
    /// <typeparam name="TModel">Domain model</typeparam>
    public interface ICreatable<TDto>
    {
        /// <summary>
        /// Создание сущности
        /// </summary>
        /// <param name="dto">DTO</param>
        /// <returns>Идентификатор созданной сущности</returns>
        Task<TDto> CreateAsync(TDto dto);
    }
}