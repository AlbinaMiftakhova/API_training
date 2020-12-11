using API_training.Models.DTO;
using API_training.Models.Requests.Books;
using API_training.Models.Responses.Books;
using AutoMapper;
using System.Collections.Generic;

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
            CreateMap<CreateBooksRequest, BookDTO>();
            CreateMap<UpdateBooksRequest, BookDTO>();
            CreateMap<BookDTO, BooksResponse>()
               .ForMember(x => x.GenreName, y => y.MapFrom(src => src.Genre.Name));
        }
    }
    
}
