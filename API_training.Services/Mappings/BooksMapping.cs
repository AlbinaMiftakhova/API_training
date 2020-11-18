using API_training.Database.Domain;
using API_training.Models.DTO;
using AutoMapper;

namespace API_training.Services.Mappings
{
    class BooksMapping : Profile
    {
        public BooksMapping()
        {
            CreateMap<Books, DTOBooks>();
        }
    }
}
