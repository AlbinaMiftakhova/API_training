using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_training.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для получения сущностей
    /// </summary>
    /// <typeparam name="TDto">DTO</typeparam>
    /// <typeparam name="TModel">Модель</typeparam>
    public interface IGettable<TDto, TModel>
    {
        /// <summary>
        /// Получение сущностей
        /// </summary>
        /// <param name="token">Экземпляр <see cref="CancellationToken"/></param>
        /// <returns></returns>
        Task<IEnumerable<TDto>> GetAsync(CancellationToken token = default);
    }
}