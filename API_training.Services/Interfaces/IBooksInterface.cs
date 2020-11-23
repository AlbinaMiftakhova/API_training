using API_training.Database.Domain;
using API_training.Models.DTO;
using System.Collections.Generic;

namespace API_training.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными о книгах
    /// </summary>
    public interface IBooksInterface
    {
        List<Books> Get();
        List<Books> GetById(long id);
        List<Books> Delete(long id);
        List<Books> Post(Books book);
        List<Books> SortByName();
    }
}
