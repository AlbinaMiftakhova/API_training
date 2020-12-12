using API_training.DAL.Domain;
using API_training.Models.DTO;
using AutoMapper;

namespace API_training.Repositories.Mappings
{
    /// <summary>
    /// Маппинг для <see cref="Genre"/>.
    /// </summary>
    public class GenreProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GenreProfile"/>.
        /// </summary>
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}
