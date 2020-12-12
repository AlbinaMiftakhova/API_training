using API_training.Models.DTO;
using API_training.Models.Requests.Books;
using API_training.Models.Requests.Genres;
using API_training.Models.Responses.Books;
using API_training.Models.Responses.Genres;
using AutoMapper;
using System.Collections.Generic;

namespace API_training.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности Жанры
    /// </summary>
    public class GenresProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GenresProfile"/>
        /// </summary>
        public GenresProfile()
        {
            CreateMap<CreateGenresRequest, GenreDTO>();
            CreateMap<UpdateGenresRequest, GenreDTO>();
            CreateMap<GenreDTO, GenresResponse>();
        }
    }
}
