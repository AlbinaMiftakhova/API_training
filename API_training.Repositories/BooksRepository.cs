using API_training.DAL.Contexts;
using API_training.DAL.Domain;
using API_training.Models.DTO;
using API_training.Repositories.Interfaces;
using AutoMapper;

namespace API_training.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями "Книги"
    /// </summary>
    public class BooksRepository : BaseRepository<DTOBooks, Books>, IBooksRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="DressRepository"/>
        /// </summary>
        /// <param name="context">Контекст данных</param>
        /// <param name="mapper">Маппер</param>
        public BooksRepository(ApiTrainingContext context, IMapper mapper) : base (context, mapper)
        {
        }
    }
}
