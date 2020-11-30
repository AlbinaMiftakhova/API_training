using System.Threading.Tasks;

namespace API_training.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для удаления сущностей
    /// </summary>
    /// <typeparam name="TDto">DTO</typeparam>
    /// <typeparam name="TModel">Модель</typeparam>
    public interface IDeletable
    {
        /// <summary>
        /// Групповое удаление сущностей
        /// </summary>
        /// <param name="ids">Идентификаторы</param>
        /// <returns>Задача, представляющая асинхронную операцию</returns>
        Task DeleteAsync(params long[] ids);
    }
}