using API_training.DAL.Domain;
using API_training.Models.DTO;
using API_training.Repositories.Interfaces.CRUD;

namespace API_training.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями "Книги"
    /// </summary>
    public interface IBooksRepository : ICrudRepository<DTOBooks, Books>
    {
    }
}
