using API_training.DAL.Domain;
using API_training.Models.DTO;
using AutoMapper;

namespace API_training.Repositories.Mappings
{
    /// <summary>
    /// Профиль маппинга (книги)
    /// </summary>
    public class BooksProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="BooksProfile"/>
        /// </summary>
        public BooksProfile()
        {
            CreateMap<Books, DTOBooks>().ReverseMap();
        }
    }
}
