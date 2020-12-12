using API_training.Models.DTO;
namespace API_training.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными об книгах
    /// </summary>
    public interface IGenresService : ICrudService<GenreDTO>
    {
    }
}
