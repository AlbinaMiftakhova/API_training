using API_training.DAL.Contexts;
using API_training.DAL.Domain;
using API_training.Models.DTO;
using API_training.Repositories.Interfaces;
using API_training.Repositories.Interfaces.CRUD;
using AutoMapper;

namespace API_training.Repositories
{
    public interface IUnitOfWork
    {
        IBooksRepository BooksRepository { get; }
        IGenresRepository GenresRepository { get; }
        void Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private ICrudRepository<Books, BookDTO> _booksRepository { get; set; }
        private ICrudRepository<Genre, GenreDTO> _genresRepository { get; set; }
        private readonly IMapper _mapper;
        protected readonly ApiTrainingContext _сontext;

        public UnitOfWork(ApiTrainingContext context, IMapper mapper)
        {
            _сontext = context;
            _mapper = mapper;
        }

        public IBooksRepository BooksRepository
        {
            get
            {
                return new BooksRepository(_сontext, _mapper);
            }
        }


        public IGenresRepository GenresRepository
        {
            get
            {
                return new GenresRepository(_сontext, _mapper);
            }
        }

        public void Save()
        {
            _сontext.SaveChanges();
        }
    }
}
