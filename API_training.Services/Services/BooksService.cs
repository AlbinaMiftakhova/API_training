using API_training.Database.Domain;
using API_training.Database.Mocks;
using API_training.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace API_training.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными о книгах.
    /// </summary>
    public class BooksService : IBooksInterface
    {
        private readonly IMapper _mapper;

        public BooksService(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Метод, получающий коллекцию сущностей "Книги" 
        /// </summary>
        /// <returns>Коллекция сущностей "Книги"</returns>
        public List<Books> Get()
        {
            return _mapper.Map<List<Books>>(MockingBooks.Books);
        }

        /// <summary>
        /// Метод, получающий сущность книги по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Сущность "Книги"</returns>
        public List<Books> GetById(long id)
        {
            var selectedById = MockingBooks.Books.Where(t => t.Id == id).ToList();
            return _mapper.Map<List<Books>>(selectedById);
        }

        /// <summary>
        /// Метод, удаляющий сущность из списка доступных книг
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns>Обновленный список сущностей "Книги"</returns>
        public List<Books> Delete(long id)
        {
            MockingBooks.Books.Remove(MockingBooks.Books.Single(t => t.Id == id));
            return _mapper.Map<List<Books>>(MockingBooks.Books);
        }

        /// <summary>
        /// Метод, добавляющий сущность в список доступных книг
        /// </summary>
        /// <param name="name">Название книги</param>
        /// <param name="author">Автор книги</param>
        /// <param name="id">Идентификатор книги</param>
        /// <param name="publisher">Издательство</param>
        /// <param name="publishingYear">Год издания</param>
        /// <returns>Обновленный список сущностей "Книги"</returns>
        public List<Books> Post(string name, string author, long id, string publisher, int publishingYear)
        {
            MockingBooks.Books.Add(new Books { Id = id, Name = name, Author = author, Publisher = publisher, PublishingYear = publishingYear });
            return _mapper.Map<List<Books>>(MockingBooks.Books);
        }

        /// <summary>
        /// Метод, сортирующий список сущностей "Книги" книги по названию
        /// </summary>
        /// <returns>Отсортированный список книг</returns>
        public List<Books> SortByName()
        {
            MockingBooks.Books.Sort((n1, n2) => n1.Name.CompareTo(n2.Name));
            return _mapper.Map<List<Books>>(MockingBooks.Books);
        }
    }
}
