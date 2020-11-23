using API_training.Database.Domain;
using API_training.Models.DTO;
using AutoMapper;

namespace API_training.Services.Mappings
{
    /// <summary>
    /// Профиль маппинга (книги)
    /// </summary>
    class BooksMapping : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="BooksMapping"/>
        /// </summary>
        public BooksMapping()
        {
            CreateMap<Books, DTOBooks>();
        }
    }
}
