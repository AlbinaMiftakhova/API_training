using API_training.Models.DTO;
using API_training.Models.Requests.Books;
using API_training.Models.Responses.Books;
using AutoMapper;

namespace API_training.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности Книги
    /// </summary>
    public class BooksProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="BooksProfile"/>
        /// </summary>
        public BooksProfile()
        {
            CreateMap<CreateBooksRequest, DTOBooks>();
            CreateMap<UpdateBooksRequest, DTOBooks>();
            CreateMap<DTOBooks, BooksResponse>();
        }
    }
}
