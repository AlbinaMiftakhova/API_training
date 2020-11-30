using System.Threading.Tasks;

namespace API_training.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для создания сущности
    /// </summary>
    /// <typeparam name="TDto">DTO</typeparam>
    /// <typeparam name="TModel">Модель</typeparam>
    public interface ICreatable<TDto, TModel>
    {
        /// <summary>
        /// Создание сущности
        /// </summary>
        /// <param name="dto">DTO.</param>
        /// <returns>Идентификатор созданной сущности.</returns>
        Task<TDto> CreateAsync(TDto dto);
    }
}