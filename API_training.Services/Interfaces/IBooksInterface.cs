using API_training.Database.Domain;
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
        List<Books> Post(string name, string author, long id, string publisher, int publishingYear);
        List<Books> SortByName();
    }
}
