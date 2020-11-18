using API_training.Database.Domain;
using API_training.Database.Mocks;
using API_training.Models.DTO;
using API_training.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace API_training.Services.Services
{
    public class BooksService : IBooksInterface
    {
        private readonly IMapper _mapper;

        public BooksService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Books> Get()
        {
            return _mapper.Map<List<Books>>(MockingBooks.Books);
        }
        public List<Books> GetByName(string name)
        {
            var SelectedByName = MockingBooks.Books.Where(t => t.Name == name).ToList();
            return _mapper.Map<List<Books>>(SelectedByName);
        }
        public List<Books> Delete(long id)
        {
            MockingBooks.Books.Remove(MockingBooks.Books.Single(t => t.Id == id));
            return _mapper.Map<List<Books>>(MockingBooks.Books);
        }
        public List<Books> Post(string name, string author, long id, string publisher, int publishingYear)
        {
            MockingBooks.Books.Add(new Books { Id = id, Name = name, Author = author, Publisher = publisher, PublishingYear = publishingYear });
            return _mapper.Map<List<Books>>(MockingBooks.Books);
        }
    }
}
